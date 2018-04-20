using POEStashChecker.NinjaDB;
using POEStashChecker.Utility;

namespace POEStashChecker.Data
{
    public struct Item
    {
        private string m_RawName;
        public string RawName
        {
            get => m_RawName;
            private set
            {
                m_RawName = value;
                Name = m_RawName.Substring(m_RawName.LastIndexOf('>') + 1);
            }
        }

        private string m_RawType;
        public string RawType
        {
            get => m_RawType;
            private set
            {
                m_RawType = value;
                Type = m_RawType.Substring(m_RawType.LastIndexOf('>') + 1);
            }
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string StashName { get; set; }
        public string Category { get; set; }
        public bool Identified { get; set; }
        public bool Unique { get; set; }
        public int MaxLinks { get; set; }
        public RectInt Size { get; set; }
        public Price Value { get; set; }
        public PoEIcon Icon { get; set; }

        public Item(dynamic item, string stashName, string league)
        {
            m_RawName = null;
            m_RawType = null;
            Name = "???";
            Type = null;
            StashName = null;
            Category = null;
            Identified = false;
            Unique = false;
            MaxLinks = 0;
            Value = new Price(0,0);
            Icon = new PoEIcon(null, 0, 0);
            Size = new RectInt(0, 0);
            SetData(item, stashName, league);
        }

        private void SetData(dynamic item, string stashName, string league)
        {
            Identified = item.identified;
            Unique = item.frameType == 3;
            MaxLinks = Extensions.GetMaxLinks(item);
            RawType = item.typeLine;
            RawName = item.name;
            if (string.IsNullOrEmpty((string) item.name))
            {
                Name = Type;
                Type = null;
            }
            Category = Extensions.GetCategory(item);
            Value = PoENinjaDB.CheckItemPrice(this, league);
            Size = new RectInt(item.w, item.h);
            Icon = new PoEIcon(item.icon, Size.Width * 16, Size.Height * 16);
            StashName = stashName;
        }

        public override string ToString()
        {
            string returnString = $"{Name} ({Type})";
            if (MaxLinks > 0)
                returnString += $", {MaxLinks}L";
            if (Unique)
                returnString += $" [U]";
            returnString += $" {Category} {Value}";
            return returnString;
        }
    }
}
