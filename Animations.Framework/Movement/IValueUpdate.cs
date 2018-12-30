using System;

namespace Animations.Framework.Movement
{
    public interface IValueUpdate
    {
        double GetValue(double percent, TimeSpan elapsedFromStart);
    }
}