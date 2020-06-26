using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeverBadWeather.DomainModel
{
    public class WeatherForecast
    {
        public TemperatureForecast[] Temperatures { get; }

        public WeatherForecast(IEnumerable<TemperatureForecast> temperatures)
        {
            Temperatures = temperatures.ToArray();
        }
    }
}
