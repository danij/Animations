namespace Animations.Framework.Drawing
{
    public class Frame
    {
        public Frame(int width, int height)
        {
            Width = width;
            Height = height;
            Bytes = new byte[BytesPerRow * height];
        }

        private const int BytesPerPixel = 4; //currently only BGRA is supported
        
        public int Width { get; }
        public int Height { get; }
        public int BytesPerRow => Width * BytesPerPixel;
        public byte[] Bytes { get; }
    }
}