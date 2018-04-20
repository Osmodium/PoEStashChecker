using POEStashChecker.Data;
using System.Net;

namespace POEStashChecker.Stash
{
    public static class StashService
    {
        private const string ENDPOINT = "https://pathofexile.com/character-window/get-stash-items?league={0}&tabs={1}&tabIndex={2}&accountName={3}";

        public static string GetStashData(string account, string league, int tabIndex, string poeSessId)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add(HttpRequestHeader.Referer, "https://www.pathofexile.com");
                wc.Headers.Add(HttpRequestHeader.Cookie, $"POESESSID={poeSessId}");
                string mergedEndPoint = string.Format(ENDPOINT, league, 1, tabIndex, account);
                return wc.DownloadString(mergedEndPoint);
            }
        }

        public static TabInfo GetTabInfo(dynamic stashData, int index)
        {
            TabInfo tabInfo = new TabInfo 
            { 
                Index = index,
                NumTabs = (int)stashData.numTabs
            };

            foreach (dynamic tab in stashData.tabs)
            {
                if (tab.i == index)
                {
                    tabInfo.Name = tab.n;
                    tabInfo.Id = tab.id;
                    tabInfo.Type = tab.type;
                    break;
                }
            }
            return tabInfo;
        }

    }
}
