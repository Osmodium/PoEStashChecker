namespace POEStashChecker.Data
{
    public struct PoEIcon
    {
        public string Url { get; set; }
        public RectInt Size { get; set; }

        public PoEIcon(string url, RectInt size)
        {
            Url = url;
            Size = size;
        }

        public PoEIcon(string url, int width, int height)
        {
            Url = url;
            Size = new RectInt(width, height);
        }
    }
}
