using System.Dynamic;
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

        public string Name;
        public string Type;
        public string Category;
        public bool Identified;
        public bool Unique;
        public int MaxLinks;
        public RectInt Size;
        public Price Value;
        public PoEIcon Icon;

        public Item(dynamic item, string league)
        {
            m_RawName = null;
            m_RawType = null;
            Name = "???";
            Type = null;
            Category = null;
            Identified = false;
            Unique = false;
            MaxLinks = 0;
            Value = new Price(0,0);
            Icon = new PoEIcon(null, 0, 0);
            Size = new RectInt(0, 0);
            SetData(item, league);
        }

        private void SetData(dynamic item, string league)
        {
            Identified = item.identified;
            Unique = item.frameType == 3;
            MaxLinks = GetMaxLinks(item);
            if (!string.IsNullOrEmpty((string)item.name))
                RawName = item.name;
            RawType = item.typeLine;
            Category = GetCategory(item);
            Value = PoENinjaDB.CheckItemPrice(this, league);
            Size = new RectInt(item.w, item.h);
            Icon = new PoEIcon(item.icon, Size.Width * 16, Size.Height * 16);
        }

        private string GetCategory(dynamic item)
        {
            return ((ExpandoObject) item.category).GetKey(0);
        }

        private int GetMaxLinks(dynamic item)
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
