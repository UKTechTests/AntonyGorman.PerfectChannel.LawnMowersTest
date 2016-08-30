namespace AntonyGorman.PerfectChannel.LawnMowersTest
{
    public struct Size
    {
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { private set; get; }
        public int Height { private set; get; }
    }
}