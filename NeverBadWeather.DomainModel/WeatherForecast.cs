using System;
using System.Collections.Generic;
using System.Text;

namespace NeverBadWeather.DomainModel
{
    public class WeatherForecast
    {
        public int Temperature { get; }

        public WeatherForecast(int temperature)
        {
            Temperature = temperature;
        }
    }
}
