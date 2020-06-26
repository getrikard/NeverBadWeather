using System;
using System.Collections.Generic;
using System.Text;

namespace NeverBadWeather.DomainModel
{
    public class TemperatureForecast
    {
        public byte Temperature { get; }
        public DateTime FromTime { get; }
        public DateTime ToTime { get; }

        public TemperatureForecast(byte temperature, DateTime fromTime, DateTime time)
        {
            Temperature = temperature;
            FromTime = fromTime;
            ToTime = time;
        }
    }
}
