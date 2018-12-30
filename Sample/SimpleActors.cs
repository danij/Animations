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
        private static readonly SKPaint BlackPaint = new SKPaint
        {
            Color = SKColors.Black,
            Style = SKPaintStyle.StrokeAndFill,
            TextSize = 24,
            TextAlign = SKTextAlign.Left,
            IsAntialias = true
        }; 
        
        public static void DrawBlueRectangle(IDrawContext context)
        {
            context.Canvas.DrawRect(new SKRect(10, 10, 200, 100), BluePaint);
        }
        
        public static void DrawRedCircle(IDrawContext context)
        {
            context.Canvas.DrawCircle(new SKPoint(600, 400), 100, RedPaint);
        }
        
        public static void DrawTime(IDrawContext context)
        {
            var time = context.Time.ToString("g");
            context.Canvas.DrawText(time, new SKPoint(50, 400), BlackPaint);
        }
    }
}