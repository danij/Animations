using System;
using Animations.Framework;
using Animations.Framework.Movement;
using SkiaSharp;

namespace Sample
{
    public class VariableWidthCircle : IActor
    {
        public VariableWidthCircle(AnimationProperties properties)
        {
            _properties = properties;
            
            _radiusValue = new MovingValue(TimeSpan.Zero, _properties.TimeLength, 
                new CosineUpdater(50, 100, TimeSpan.FromSeconds(1)));
        }
        
        public void Perform(IDrawContext context)
        {
            var radius = _radiusValue.GetValue(context.Time);
            context.Canvas.DrawCircle(new SKPoint(300, 400), (float)radius, RedPaint);
        }

        private static readonly SKPaint RedPaint = new SKPaint
        {
            Color = SKColors.Red, 
            Style = SKPaintStyle.StrokeAndFill,
            IsAntialias = true
        };
        private readonly AnimationProperties _properties;
        private readonly MovingValue _radiusValue;
    }
}