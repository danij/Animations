using System;

namespace Animations.Framework.Movement
{
    public class MovingValue
    {
        public MovingValue(TimeSpan start, TimeSpan length, IValueUpdate updater)
        {
            _start = start;
            _length = length;
            _updater = updater;
        }

        public double GetValue(TimeSpan at)
        {
            var percent = (at.TotalSeconds - _start.TotalSeconds) / _length.TotalSeconds;
            percent = Math.Min(1, Math.Max(0, percent));
            var elapsed = at - _start;
            
            return _updater.GetValue(percent, elapsed);
        }
        
        private readonly TimeSpan _start;
        private readonly TimeSpan _length;
        private readonly IValueUpdate _updater;
    }
}