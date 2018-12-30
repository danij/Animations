using System;
using Animations.Framework;
using Animations.Framework.Output;
using SkiaSharp;

namespace Sample
{
    internal static class Program
    {
        private static void CreateSampleAnimation()
        {
            var properties = new AnimationProperties(800, 600,
                AnimationLength.FromLength(TimeSpan.FromSeconds(4)), 25.0f);
            using (var output = new FFMpegOutput("animation.mp4", properties))
            {
                var animation = new Animation(properties, SKColors.White, output);
                animation.Run(
                    new ActorEntry(new ActorDelegate(SimpleActors.DrawBlueRectangle),
                        AnimationTimePoint.Start, AnimationTimePoint.FromTime(TimeSpan.FromSeconds(2))),
                    new ActorEntry(new ActorDelegate(SimpleActors.DrawRedCircle),
                        AnimationTimePoint.FromTime(TimeSpan.FromSeconds(1.5)),
                        AnimationTimePoint.FromTime(TimeSpan.FromSeconds(3.5))),
                    new ActorEntry(new ActorDelegate(SimpleActors.DrawTime),
                        AnimationTimePoint.Start, AnimationTimePoint.Finish),
                    new ActorEntry(new ProgressBar(properties), AnimationTimePoint.Start, AnimationTimePoint.Finish),
                    new ActorEntry(new VariableWidthCircle(properties), AnimationTimePoint.Start,
                        AnimationTimePoint.Finish)
                );
            }
        }

        private static void Main(string[] args)
        {
            CreateSampleAnimation();
        }
    }
}