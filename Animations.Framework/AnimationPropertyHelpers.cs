using System;

namespace Animations.Framework
{
    public static class AnimationPropertyHelpers
    {
        public static int GetFrameNumber(this AnimationTimePoint timePoint, AnimationProperties properties)
        {
            switch (timePoint.Type)
            {
                case AnimationTimePoint.ValueType.Start:
                    return 0;
                case AnimationTimePoint.ValueType.Finish:
                    return int.MaxValue;
                case AnimationTimePoint.ValueType.FrameNumber:
                    return (int) timePoint.Value;
                case AnimationTimePoint.ValueType.Time:
                    return (int)(((TimeSpan) timePoint.Value).TotalSeconds * properties.Fps);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}