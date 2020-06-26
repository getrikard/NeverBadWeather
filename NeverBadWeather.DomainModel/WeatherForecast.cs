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

        public override string ToString()
        {
            return string.Join(Environment.NewLine, Temperatures.Select(t => t.ToString()));
        }
    }
}
