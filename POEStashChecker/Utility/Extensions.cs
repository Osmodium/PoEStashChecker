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
    }
}
