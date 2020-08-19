using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace NeverBadWeather.DomainModel.UnitTest
{
    class ClothingRuleTest
    {
        [Test]
        public void TestMatchWithInt()
        {
            // Arrange
            var clothingRule = new ClothingRule(10, 20, false, "ingenting");
            
            // Act
            var goodMatches = new[]
            {
                clothingRule.Match(10),
                clothingRule.Match(15),
                clothingRule.Match(20),
            };

            var badMatches = new[]
            {
                clothingRule.Match(5),
                clothingRule.Match(9),
                clothingRule.Match(21),
                clothingRule.Match(25),
                clothingRule.Match(-2),
            };

            // Assert
            foreach (var goodMatch in goodMatches)
            {
                Assert.IsTrue(goodMatch);
            }

            foreach (var badMatch in badMatches)
            {
                Assert.IsFalse(badMatch);
            }
        }

        [Test]
        public void TestMatchWithStats()
        {
            // Arrange
            var clothingRule = new ClothingRule(10, 20, null, "ingenting");

            // Act
            var stats1 = new TemperatureStatistics();
            stats1.AddTemperature(10);
            stats1.AddTemperature(20);

            var stats2 = new TemperatureStatistics();
            stats2.AddTemperature(5);
            stats2.AddTemperature(25);

            var stats3 = new TemperatureStatistics();
            stats3.AddTemperature(21);
            stats3.AddTemperature(31);

            var stats4 = new TemperatureStatistics();
            stats4.AddTemperature(5);
            stats4.AddTemperature(15);

            // Assert
            Assert.IsTrue(clothingRule.Match(stats1));
            Assert.IsFalse(clothingRule.Match(stats2));
            Assert.IsFalse(clothingRule.Match(stats3));
            Assert.IsTrue(clothingRule.Match(stats4));
        }
    }
}
