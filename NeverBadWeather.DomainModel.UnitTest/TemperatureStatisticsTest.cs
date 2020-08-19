using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace NeverBadWeather.DomainModel.UnitTest
{
    class TemperatureStatisticsTest
    {
        [Test]
        public void TestAddTemperature()
        {
            // Arrange
            var temperatureStats = new TemperatureStatistics();

            // Act and Assert
            temperatureStats.AddTemperature(10);
            Assert.AreEqual(10, temperatureStats.Min);
            Assert.AreEqual(10, temperatureStats.Max);

            temperatureStats.AddTemperature(8);
            Assert.AreEqual(8, temperatureStats.Min);
            Assert.AreEqual(10, temperatureStats.Max);

            temperatureStats.AddTemperature(12);
            Assert.AreEqual(8, temperatureStats.Min);
            Assert.AreEqual(12, temperatureStats.Max);
        }
    }
}
