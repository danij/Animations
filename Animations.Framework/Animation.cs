using System;
using System.Runtime.InteropServices;
using Animations.Framework.Drawing;
using Animations.Framework.Output;
using SkiaSharp;

namespace Animations.Framework
{
    public class Animation
    {
        public Animation(AnimationProperties properties, SKColor backgroundColor, IVideoOutput output)
        {
            _properties = properties;
            _backgroundColor = backgroundColor;
            _output = output;
            
            _frame = new Frame(properties.Width, properties.Height);
            _frameCount = properties.FrameCount;

            _imageInfo = new SKImageInfo(properties.Width, properties.Height, SKColorType.Bgra8888);
        }

        public void Run(params ActorEntry[] actors)
        {
            var actorCollection = new ActorCollection(_properties, actors);

            for (int i = 0; i < _frameCount; i++)
            {
                RenderFrame(i, actorCollection);
                _output.Write(_frame);
            }
        }

        private void RenderFrame(int frameNumber, ActorCollection actorCollection)
        {
            var context = new DrawContext
            {
                AnimationProperties = _properties,
                FrameNumber = frameNumber,
                Time = TimeSpan.FromSeconds((float) frameNumber / _properties.Fps)
            };
            DrawOnCurrentFrame(canvas =>
            {
                context.Canvas = canvas;
                actorCollection.InvokeActors(context);
            });
        }

        private void DrawOnCurrentFrame(Action<SKCanvas> callback)
        {
            var pinnedBytes = GCHandle.Alloc(_frame.Bytes, GCHandleType.Pinned);
            using (var surface = SKSurface.Create(_imageInfo, pinnedBytes.AddrOfPinnedObject(), _frame.BytesPerRow))
            {
                var canvas = surface.Canvas;
                canvas.Clear(_backgroundColor);
                callback(canvas);
            }
        }

        private readonly AnimationProperties _properties;
        private readonly SKColor _backgroundColor;
        private readonly IVideoOutput _output;
        private readonly int _frameCount;
        private readonly Frame _frame;
        private readonly SKImageInfo _imageInfo;
    }
}