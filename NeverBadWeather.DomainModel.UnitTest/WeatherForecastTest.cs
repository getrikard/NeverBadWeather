using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace NeverBadWeather.DomainModel.UnitTest
{
    class WeatherForecastTest
    {
        [Test]
        public void TestStats()
        {
            // Arrange
            var temperatures = new[]
            {
                new TemperatureForecast(16, new DateTime(2020,8,4, 12, 0, 0), new DateTime(2020,8,4, 13, 0, 0)),
                new TemperatureForecast(12, new DateTime(2020,8,4, 13, 0, 0), new DateTime(2020,8,4, 14, 0, 0)),
                new TemperatureForecast(18, new DateTime(2020,8,4, 14, 0, 0), new DateTime(2020,8,4, 15, 0, 0)),
            };
            var weatherForecast = new WeatherForecast(temperatures);

            // Act
            var temperatureStats = weatherForecast.GetStats();

            // Assert
            Assert.AreEqual(12, temperatureStats.Min);
            Assert.AreEqual(18, temperatureStats.Max);
        }
    }
}
