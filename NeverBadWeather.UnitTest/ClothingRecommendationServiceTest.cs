using System;
using System.Threading.Tasks;
using Moq;
using NeverBadWeather.ApplicationServices;
using NeverBadWeather.DomainModel;
using NeverBadWeather.DomainServices;
using NUnit.Framework;

namespace NeverBadWeather.UnitTest
{
    public class ClothingRecommendationServiceTest
    {

        [Test]
        public async Task TestHappyCase()
        {
            // arrange
            var testDate = new DateTime(2000, 1, 1, 10, 0, 0);
            var testPeriod = new TimePeriod(testDate, testDate.AddHours(10));
            var testLocation = new Location(59, 10);

            var mockWeatherForecastService = new Mock<IWeatherForecastService>();
            var mockClothingRuleRepository = new Mock<IClothingRuleRepository>();

            mockClothingRuleRepository
                .Setup(crr => crr.GetRulesByUser(It.IsAny<Guid?>()))
                .ReturnsAsync(new[]
                {
                    new ClothingRule(-20, 10, null, "Bobledress"),
                    new ClothingRule(10, 20, null, "Bukse og genser"),
                    new ClothingRule(20, 40, null, "T-skjore og shorts"),
                });


            mockWeatherForecastService
                .Setup(fs => fs.GetAllPlaces())
                .Returns(new[] { new Place("", "", "", "Andeby", new Location(59.1f, 10.1f)), });

            mockWeatherForecastService
                .Setup(fs => fs.GetWeatherForecast(It.IsAny<Place>()))
                .ReturnsAsync(new WeatherForecast(new[] {
                    new TemperatureForecast(25,testDate.AddHours(2), testDate.AddHours(4)),
                }));

            // act
            var request = new ClothingRecommendationRequest(testPeriod, testLocation);
            var service = new ClothingRecommendationService(
                mockWeatherForecastService.Object,
                mockClothingRuleRepository.Object);
            var recommendation = await service.GetClothingRecommendation(request);

            // assert
        }
    }
}