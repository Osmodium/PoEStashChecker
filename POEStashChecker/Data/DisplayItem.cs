using POEStashChecker.NinjaDB;
using POEStashChecker.Utility;

namespace POEStashChecker.Data
{
    public struct DisplayItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string StashName { get; set; }
        public string Category { get; set; }
        public bool Identified { get; set; }
        public bool Unique { get; set; }
        public int MaxLinks { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int AbyssalSockets { get; set; }
        public int Quality { get; set; }
        public int Level { get; set; }
        public bool Corrupted { get; set; }
        public int StackSize { get; set; }
        public double ChaosValue { get; set; }
        public double ExaltedValue { get; set; }

        public void SetData(dynamic item, string stashName, string league)
        {
            Identified = item.identified;
            Unique = item.frameType == 3;
            MaxLinks = Extensions.GetMaxLinks(item);
            string rawType = item.typeLine;
            Type = rawType.Substring(rawType.LastIndexOf('>') + 1);
            string rawName = item.name;
            Name = rawName.Substring(rawName.LastIndexOf('>') + 1);

            if (string.IsNullOrEmpty((string) item.name))
            {
                Name = Type;
                Type = null;
            }

            Category = Extensions.GetCategory(item);
            Height = (int)item.h;
            Width = (int) item.w;

            Price price = PoENinjaDB.CheckItemPrice(this, league);
            ChaosValue = price.ChaosOrb;
            ExaltedValue = price.ExaltedOrb;
            StashName = stashName;

            AbyssalSockets = Extensions.GetAbyssalSockets(item);

            Quality = Extensions.GetQuality(item, Category);
        }

        public override string ToString()
        {
            string returnString = $"{Name} ({Type})";
            if (MaxLinks > 0)
                returnString += $", {MaxLinks}L";
            if (Unique)
                returnString += $" [U]";
            returnString += $" {Category}";
            return returnString;
        }
    }
}
