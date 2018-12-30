using Animations.Framework;
using SkiaSharp;

namespace Sample
{
    public static class SimpleActors
    {
        private static readonly SKPaint BluePaint = new SKPaint
        {
            Color = SKColors.Blue, 
            Style = SKPaintStyle.Stroke
        }; 
        private static readonly SKPaint RedPaint = new SKPaint
        {
            Color = SKColors.Red,
            Style = SKPaintStyle.StrokeAndFill,
            IsAntialias = true
        }; 
        
        public static void DrawBlueRectangle(IDrawContext context)
        {
            context.Canvas.DrawRect(new SKRect(10, 10, 200, 100), BluePaint);
        }
        
        public static void DrawRedCircle(IDrawContext context)
        {
            context.Canvas.DrawCircle(new SKPoint(400, 400), 100, RedPaint);
        }
    }
}