using System;
using System.Collections.Generic;
using System.Text;
using NeverBadWeather.DomainModel.Exception;

namespace NeverBadWeather.DomainModel
{
    public class TemperatureStatistics
    {
        private byte _min;
        private byte _max;

        public byte Min
        {
            get
            {
                if (_hasNoInput) throw new CannotGiveMinOrMaxWithNoNumbersException();
                return _min;
            }
        }

        public byte Max
        {
            get
            {
                if (_hasNoInput) throw new CannotGiveMinOrMaxWithNoNumbersException();
                return _min;
            }
        }

        private bool _hasNoInput = true;

        public void AddTemperature(byte temperature)
        {
            if (_hasNoInput)
            {
                _max = _min = temperature;
                _hasNoInput = false;
                return;
            }
            _max = Math.Max(_max, temperature);
            _min = Math.Min(_min, temperature);
        }
    }
}
