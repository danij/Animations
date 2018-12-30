using System;
using Animations.Framework;
using Animations.Framework.Movement;
using SkiaSharp;

namespace Sample
{
    public class ProgressBar : IActor
    {
        public ProgressBar(AnimationProperties properties)
        {
            _properties = properties;
            var finishTime = _properties.TimeLength - TimeSpan.FromSeconds(1);
            
            _linearRightValue = new MovingValue(TimeSpan.Zero, finishTime, 
                new LinearUpdater(0, _properties.Width));
            _squareRootRightValue = new MovingValue(TimeSpan.Zero, finishTime, 
                new PowerUpdater(0, _properties.Width, 0.5));
            _squareRightValue = new MovingValue(TimeSpan.Zero, finishTime, 
                new PowerUpdater(0, _properties.Width, 2));
            _power3RightValue = new MovingValue(TimeSpan.Zero, finishTime, 
                new PowerUpdater(0, _properties.Width, 3));
        }
        
        public void Perform(IDrawContext context)
        {
            var linearRight = _linearRightValue.GetValue(context.Time);
            context.Canvas.DrawRect(new SKRect(0, 150, (float)linearRight, 160), BluePaint);

            var squareRootRight = _squareRootRightValue.GetValue(context.Time);
            context.Canvas.DrawRect(new SKRect(0, 170, (float)squareRootRight, 180), BluePaint);

            var squareRight = _squareRightValue.GetValue(context.Time);
            context.Canvas.DrawRect(new SKRect(0, 190, (float)squareRight, 200), BluePaint);

            var power3Right = _power3RightValue.GetValue(context.Time);
            context.Canvas.DrawRect(new SKRect(0, 210, (float)power3Right, 220), BluePaint);
        }

        private static readonly SKPaint BluePaint = new SKPaint
        {
            Color = SKColors.Blue, 
            Style = SKPaintStyle.StrokeAndFill
        };
        private readonly AnimationProperties _properties;
        private readonly MovingValue _linearRightValue;
        private readonly MovingValue _squareRootRightValue;
        private readonly MovingValue _squareRightValue;
        private readonly MovingValue _power3RightValue;
    }
}