using System;
using SkiaSharp;

namespace Animations.Framework
{
    public interface IDrawContext
    {
        AnimationProperties AnimationProperties { get; }
        int FrameNumber { get; }
        TimeSpan Time { get; }
        SKCanvas Canvas { get; }
    }

    internal class DrawContext : IDrawContext
    {
        public AnimationProperties AnimationProperties { get; set; }
        public int FrameNumber { get; set; }
        public TimeSpan Time { get; set; }
        public SKCanvas Canvas { get; set; }
    }
}