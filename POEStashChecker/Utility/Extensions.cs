using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace POEStashChecker.Utility
{
    public static class Extensions
    {
        public static bool ContainsKey(this ExpandoObject expandoObject, string key)
        {
            if (!(expandoObject is IDictionary<string, object> expandoDict))
                return false;

            return expandoDict.ContainsKey(key);
        }

        public static string GetKey(this ExpandoObject expandoObject, int i)
        {
            if (!(expandoObject is IDictionary<string, object> expandoDict))
                return null;

            return expandoDict.Keys.ElementAt(i);
        }

        public static IDictionary<string, object> ConvertToDictionary(this ExpandoObject expandoObject)
        {
            if (!(expandoObject is IDictionary<string, object> expandoDict))
                return null;
            return expandoDict;
        }

        public static string GetCategory(dynamic item)
        {
            return ((ExpandoObject)item.category).GetKey(0);
        }

        public static int GetMaxLinks(dynamic item)
        {
            int maxLinks = 0;
            long currentGroup = -1;
            int currentGroupLinks = 0;

            if (!((ExpandoObject)item).ContainsKey("sockets"))
                return maxLinks;

            foreach (dynamic socket in item.sockets)
            {
                if (socket.group != currentGroup)
                {
                    if (currentGroupLinks > maxLinks)
                        maxLinks = currentGroupLinks;
                    currentGroupLinks = 0;
                    currentGroup = socket.group;
                }
                ++currentGroupLinks;
            }

            if (currentGroupLinks > maxLinks)
                maxLinks = currentGroupLinks;

            return maxLinks;
        }

        public static int GetAbyssalSockets(dynamic item)
        {
            int abyssalSockets = 0;

            if (!((ExpandoObject)item).ContainsKey("sockets"))
                return abyssalSockets;

            foreach (dynamic socket in item.sockets)
            {
                if (socket.sColour == "A")
                    abyssalSockets++;
            }

            return abyssalSockets;
        }

        public static int GetQuality(dynamic item, string category)
        {
            switch (category)
            {
                case "accessories":
                case "armour":
                case "flasks":
                case "jewels":
                case "weapons":
                {
                    {
                        if (!((ExpandoObject) item).ContainsKey("properties"))
                            return 0;
                        foreach (dynamic property in item.properties)
                        {
                            if (property.name.Equals("Quality"))
                            {
                                return int.Parse(property.values[0][0].Trim(new[] {'+', '%'}));
                            }
                        }
                        break;
                    }
                }
            }
            return 0;
        }

        //public static int GetLevel(dynamic item, string category)
        //{

        //}

    }
}
