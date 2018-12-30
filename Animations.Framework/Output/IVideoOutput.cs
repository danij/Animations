using System;
using Animations.Framework.Drawing;

namespace Animations.Framework.Output
{
    public interface IVideoOutput : IDisposable
    {
        void Write(Frame frame);
    }
}