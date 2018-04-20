namespace POEStashChecker.Data
{
    public struct RectInt
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public RectInt(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public RectInt(string width, string height)
        {
            Width = int.Parse(width);
            Height = int.Parse(height);
        }

        public RectInt(long width, long height)
        {
            Width = (int)width;
            Height = (int)height;
        }
    }

    public struct RectFloat
    {
        public float Width { get; set; }
        public float Height { get; set; }

        public RectFloat(float width, float height)
        {
            Width = width;
            Height = height;
        }
    }
}