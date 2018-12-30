using System;

namespace Animations.Framework
{
    public class AnimationProperties
    {
        public AnimationProperties(int width, int height, AnimationLength length, float fps)
        {
            Width = width;
            Height = height;
            Length = length;
            Fps = fps;
        }

        public int FrameCount
        {
            get
            {
                switch (Length.Type)
                {
                    case AnimationLength.ValueType.FrameCount:
                        return (int) Length.Value;
                    case AnimationLength.ValueType.TimeLength:
                        return (int)Math.Ceiling(((TimeSpan) Length.Value).TotalSeconds * Fps);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        
        public int Width { get; }
        public int Height { get; }
        public AnimationLength Length { get; }
        public float Fps { get; }
    }

    public class AnimationLength
    {
        public static AnimationLength FromFrameCount(int frameCount)
        {
            return new AnimationLength(ValueType.FrameCount, frameCount);
        }
        
        public static AnimationLength FromLength(TimeSpan length)
        {
            return new AnimationLength(ValueType.TimeLength, length);
        }
        
        private AnimationLength(ValueType type, object value)
        {
            Type = type;
            Value = value;
        }

        public enum ValueType
        {
            FrameCount,
            TimeLength
        }
        
        public ValueType Type { get; }
        public object Value { get; }
    }

    public class AnimationTimePoint
    {
        public static AnimationTimePoint Start { get; } = new AnimationTimePoint(ValueType.Start, null);
        public static AnimationTimePoint Finish { get; } = new AnimationTimePoint(ValueType.Finish, null);

        public static AnimationTimePoint FromFrameNumber(int frameNumber)
        {
            return new AnimationTimePoint(ValueType.FrameNumber, frameNumber);
        }

        public static AnimationTimePoint FromTime(TimeSpan time)
        {
            return new AnimationTimePoint(ValueType.Time, time);
        }
        
        public AnimationTimePoint(ValueType type, object value)
        {
            Type = type;
            Value = value;
        }

        public enum ValueType
        {
            Start,
            Finish,
            FrameNumber,
            Time
        }
        
        public ValueType Type { get; }
        public object Value { get; }
    }
}