using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using POEStashChecker.Data;

namespace POEStashChecker.NinjaDB
{
    public static class PoENinjaDB
    {
        private const string DB_FILE_PATH = @"NinjaDB";

        // Gotten from 
        // https://www.reddit.com/r/pathofexiledev/comments/6vxowg/list_of_poeninja_api_links/
        private const string CURRENCY_DATA_ENDPOINT = "http://cdn.poe.ninja/api/Data/GetCurrencyOverview?league={0}";
        private const string FRAGMENT_DATA_ENDPOINT = "http://cdn.poe.ninja/api/Data/GetFragmentOverview?league={0}";
        private const string ESSENCE_DATA_ENDPOINT = "http://cdn.poe.ninja/api/Data/GetEssenceOverview?league={0}";
        private const string DIVINATION_CARDS_DATA_ENDPOINT = "http://cdn.poe.ninja/api/Data/GetDivinationCardsOverview?league={0}";
        private const string PROPHECY_DATA_ENDPOINT = "http://cdn.poe.ninja/api/Data/GetProphecyOverview?league={0}";
        private const string UNIQUE_BEAST_DATA_ENDPOINT = "http://cdn.poe.ninja/api/Data/GetUniqueBeastOverview?league={0}";
        private const string RARE_BEAST_DATA_ENDPOINT = "http://cdn.poe.ninja/api/Data/GetRareBeastOverview?league={0}";
        private const string GEM_SKILL_DATA_ENDPOINT = "http://cdn.poe.ninja/api/Data/GetSkillGemOverview?league={0}";
        private const string UNIQUE_MAP_DATA_ENDPOINT = "http://cdn.poe.ninja/api/Data/GetUniqueMapOverview?league={0}";
        private const string MAP_DATA_ENDPOINT = "http://cdn.poe.ninja/api/Data/GetMapOverview?league={0}";
        private const string UNIQUE_JEWEL_DATA_ENDPOINT = "http://cdn.poe.ninja/api/Data/GetUniqueJewelOverview?league={0}";
        private const string UNIQUE_FLASK_DATA_ENDPOINT = "http://cdn.poe.ninja/api/Data/GetUniqueFlaskOverview?league={0}";
        private const string UNIQUE_WEAPON_DATA_ENDPOINT = "http://cdn.poe.ninja/api/Data/GetUniqueWeaponOverview?league={0}";
        private const string UNIQUE_ARMOUR_DATA_ENDPOINT = "http://cdn.poe.ninja/api/Data/GetUniqueArmourOverview?league={0}";
        private const string UNIQUE_ACCESSORY_DATA_ENDPOINT = "http://cdn.poe.ninja/api/Data/GetUniqueAccessoryOverview?league={0}";

        private static List<SubDb> m_LoadedDbs = new List<SubDb>();

        private static double m_ExaltedValue;

        private static SubDb LoadSubDb(string name, string league)
        {
            SubDb subDb = m_LoadedDbs.SingleOrDefault(sDb => sDb.Name.Equals(name) && sDb.League.Equals(league));
            if (subDb != null)
                return subDb;

            FileInfo currentAssemblyFileInfo = new FileInfo(Assembly.GetEntryAssembly().Location);

            string dbJson = null;
            string dbPath = Path.Combine(currentAssemblyFileInfo.DirectoryName, DB_FILE_PATH, $"{name}_{league}.ninjadb");
            FileInfo fileInfo = new FileInfo(dbPath);
            if (!Directory.Exists(fileInfo.DirectoryName))
                Directory.CreateDirectory(fileInfo.DirectoryName);
            if (fileInfo.Exists)
                dbJson = File.ReadAllText(fileInfo.FullName, Encoding.UTF8);
            else
            {
                dbJson = GetNinjaJsonData(name, league);
                File.WriteAllText(dbPath, dbJson, Encoding.UTF8);
            }
            dynamic db = JsonConvert.DeserializeObject<ExpandoObject>(dbJson);
            subDb = new SubDb(name, league, db);
            m_LoadedDbs.Add(subDb);

            return subDb;
        }

        private static string GetNinjaJsonData(string name, string league)
        {
            string dbJson = null;
            string endPoint = null;
            switch (name)
            {
                case "currency":
                {
                    endPoint = CURRENCY_DATA_ENDPOINT;
                    break;
                }
                case "gems":
                {
                    endPoint = GEM_SKILL_DATA_ENDPOINT;
                    break;
                }
                case "cards":
                {
                    endPoint = DIVINATION_CARDS_DATA_ENDPOINT;
                    break;
                }
                case "maps":
                {
                    endPoint = MAP_DATA_ENDPOINT;
                    break;
                }
                case "accessories":
                {
                    endPoint = UNIQUE_ACCESSORY_DATA_ENDPOINT;
                    break;
                }
                case "armour":
                {
                    endPoint = UNIQUE_ARMOUR_DATA_ENDPOINT;
                    break;
                }
                case "flasks":
                {
                    endPoint = UNIQUE_FLASK_DATA_ENDPOINT;
                    break;
                }
                case "jewels":
                {
                    endPoint = UNIQUE_JEWEL_DATA_ENDPOINT;
                    break;
                }
                case "weapons":
                {
                    endPoint = UNIQUE_WEAPON_DATA_ENDPOINT;
                    break;
                }
            }
            endPoint = string.Format(endPoint, league);

            using (WebClient wc = new WebClient())
            {
                dbJson = wc.DownloadString(endPoint);
            }

            return dbJson;
        }

        public static Price CheckItemPrice(Item item, string league)
        {
            if (item.Unique)
            {
                SubDb subDb = LoadSubDb(item.Category, league);
                foreach (dynamic line in subDb.Db.lines)
                {
                    if (line.name.Equals(item.Name) && item.MaxLinks >= line.links)
                    {
                        return new Price(line.chaosValue, line.exaltedValue);
                    }
                }
            }
            return new Price(0, 0);
        }

        private static void SetExaltedValue(string league)
        {
            if (m_ExaltedValue > 0)
                return;

            SubDb subDb = LoadSubDb("currency", league);
            foreach (dynamic line in subDb.Db.lines)
            {
                if (line.currencyTypeName.Equals("Exalted Orb"))
                    m_ExaltedValue = line.receive.value;
            }
        }

        public static Price CheckItemPrice(DisplayItem item, string league)
        {
            SubDb subDb = LoadSubDb(item.Category, league);
            switch (item.Category)
            {
                case "currency":
                case "fragment":
                {
                    SetExaltedValue(league);
                    foreach (dynamic line in subDb.Db.lines)
                    {
                        if (line.currencyTypeName.Equals(item.Name))
                            return new Price(line.receive.value, line.receive.value / m_ExaltedValue);
                    }
                    return new Price(0, 0);
                }
                //case "gems":
                //{

                    
                //}
                
                
                //case "maps":
                //{

                    
                //}
                case "essence":
                case "cards":
                {
                    foreach (dynamic line in subDb.Db.lines)
                    {
                        if (line.name.Equals(item.Name))
                            return new Price(line.chaosValue, line.exaltedValue);
                    }
                    return new Price(0, 0);
                }
                case "accessories":
                case "armour":
                case "flasks":
                case "jewels":
                case "weapons":
                {
                    if (!item.Unique)
                        return new Price(0, 0);

                    foreach (dynamic line in subDb.Db.lines)
                    {
                        if (line.name.Equals(item.Name) && item.MaxLinks >= line.links)
                        {
                            if (string.IsNullOrEmpty(line.variant))
                                return new Price(line.chaosValue, line.exaltedValue);
                            else
                            {
                                string variant = (string)line.variant;
                                int abyssal = int.Parse(variant.Substring(0, variant.IndexOf(' ')));
                                if (item.AbyssalSockets >= abyssal)
                                    return new Price(line.chaosValue, line.exaltedValue);
                            }
                        }
                    }
                    return new Price(0, 0);
                }
            }
            return new Price(0, 0);
        }

    }
}
