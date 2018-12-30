using Animations.Framework;
using Animations.Framework.Output;
using SkiaSharp;

namespace Sample
{
    internal static class Program
    {
        private static void CreateSampleAnimation()
        {
            var properties = new AnimationProperties(800, 600, AnimationLength.FromFrameCount(10), 2.0f);
            using (var output = new FFMpegOutput("animation.mp4", properties))
            {
                var animation = new Animation(properties, SKColors.White, output);
                animation.Run(
                    new ActorEntry(new ActorDelegate(SimpleActors.DrawBlueRectangle),
                        AnimationTimePoint.Start, AnimationTimePoint.FromFrameNumber(5)),
                    new ActorEntry(new ActorDelegate(SimpleActors.DrawRedCircle),
                        AnimationTimePoint.FromFrameNumber(3), AnimationTimePoint.FromFrameNumber(7))
                );
            }
        }

        private static void Main(string[] args)
        {
            CreateSampleAnimation();
        }
    }
}