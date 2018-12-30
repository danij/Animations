using System;

namespace Animations.Framework.Movement
{
    public class ConstantUpdater : IValueUpdate
    {
        public ConstantUpdater(double value)
        {
            _value = value;
        }

        public double GetValue(double percent, TimeSpan elapsedFromStart)
        {
            return _value;
        }

        private readonly double _value;
    }
    
    public class LinearUpdater : IValueUpdate
    {
        public LinearUpdater(double from, double to)
        {
            _from = from;
            _to = to;
        }

        public double GetValue(double percent, TimeSpan elapsedFromStart)
        {
            return (_to - _from) * percent + _from;
        }

        private readonly double _from;
        private readonly double _to;
    }
    
    public class PowerUpdater : IValueUpdate
    {
        public PowerUpdater(double from, double to, double power)
        {
            _from = from;
            _to = to;
            _power = power;
        }

        public double GetValue(double percent, TimeSpan elapsedFromStart)
        {
            return (_to - _from) * Math.Pow(percent, _power) + _from;
        }

        private readonly double _from;
        private readonly double _to;
        private readonly double _power;
    }
    
    public class CosineUpdater : IValueUpdate
    {
        public CosineUpdater(double from, double to, TimeSpan period)
        {
            _from = from;
            _to = to;
            _period = period;
        }

        public double GetValue(double percent, TimeSpan elapsedFromStart)
        {
            var x = elapsedFromStart.TotalSeconds * 2 * Math.PI / _period.TotalSeconds;
            return (_to - _from) * (Math.Cos(x) + 1) / 2 + _from;
        }

        private readonly double _from;
        private readonly double _to;
        private readonly TimeSpan _period;
    }
}