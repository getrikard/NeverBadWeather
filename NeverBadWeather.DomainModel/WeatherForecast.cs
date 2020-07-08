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

        public TemperatureStatistics GetStats(DateTime from, DateTime to)
        {
            var stats = new TemperatureStatistics();
            foreach (var temperature in Temperatures)
            {
                if (temperature.FromTime >= from || temperature.ToTime <= to)
                {
                    stats.AddTemperature(temperature.Temperature);
                }
            }

            return stats;
        }
    }
}
