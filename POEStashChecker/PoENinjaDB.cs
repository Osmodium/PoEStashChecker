using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace POEStashChecker
{
    public class SubDb
    {
        public string Name;
        public string League;
        public dynamic Db;

        public SubDb(string name, string league, dynamic db)
        {
            Name = name;
            League = league;
            Db = db;
        }
    }

    public static class PoENinjaDB
    {
        private const string DB_FILE_PATH = @"NinjaDB";

        // Gotten from 
        // https://www.reddit.com/r/pathofexiledev/comments/6vxowg/list_of_poeninja_api_links/
        private const string UNIQUE_ACCESSORY_DATA_ENDPOINT = "http://cdn.poe.ninja/api/Data/GetUniqueAccessoryOverview?league={0}";
        private const string UNIQUE_ARMOUR_DATA_ENDPOINT = "http://cdn.poe.ninja/api/Data/GetUniqueArmourOverview?league={0}";
        private const string UNIQUE_FLASK_DATA_ENDPOINT = "http://cdn.poe.ninja/api/Data/GetUniqueFlaskOverview?league={0}";
        private const string UNIQUE_JEWEL_DATA_ENDPOINT = "http://cdn.poe.ninja/api/Data/GetUniqueJewelOverview?league={0}";
        private const string UNIQUE_WEAPON_DATA_ENDPOINT = "http://cdn.poe.ninja/api/Data/GetUniqueWeaponOverview?league={0}";
        // Todo add all...

        private static List<SubDb> m_LoadedDbs = new List<SubDb>();

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
    }
}
