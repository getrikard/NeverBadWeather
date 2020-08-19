using System;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NeverBadWeather.ApplicationServices;
using NeverBadWeather.DomainModel;
using NeverBadWeather.DomainModel.Exception;
using NeverBadWeather.DomainServices;
using NeverBadWeather.Infrastructure.DataAccess;
using NeverBadWeather.Infrastructure.WeatherForecastService;
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
            Assert.AreEqual("Andeby", recommendation.Place.Name);
            Assert.That(recommendation.Rules, Has.Exactly(1).Items);
            var rule = recommendation.Rules.First();
            Assert.AreEqual("T-skjore og shorts", rule.Clothes);
        }

        [Test]
        public async Task TestLocationIsTooFarFromAnyPlaceSoWeShouldNotGetAnyRecommendations()
        {
            // arrange
            var testDate = new DateTime(2000, 1, 1, 10, 0, 0);
            var testPeriod = new TimePeriod(testDate, testDate.AddHours(10));
            var testLocation = new Location(59, -10);

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
                .Returns(new[] { new Place("", "", "", "Larvik", new Location(59, 0)), });

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
            Assert.That(recommendation.Rules, Has.Exactly(0).Items);
        }

        [Test]
        public async Task TestLocationIsInvalid()
        {
            // arrange
            var testDate = new DateTime(2000, 1, 1, 10, 0, 0);
            var testPeriod = new TimePeriod(testDate, testDate.AddHours(10));
            var testLocation = new Location(100, 10);

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
                .Returns(new[] { new Place("", "", "", "Larvik", new Location(59, 0)), });

            mockWeatherForecastService
                .Setup(fs => fs.GetWeatherForecast(It.IsAny<Place>()))
                .ReturnsAsync(new WeatherForecast(new[] {
                    new TemperatureForecast(25,testDate.AddHours(2), testDate.AddHours(4)),
                }));

            // act
            var request = new ClothingRecommendationRequest(testPeriod, testLocation);
            var service = new ClothingRecommendationService(mockWeatherForecastService.Object, mockClothingRuleRepository.Object);
            var recommendation = await service.GetClothingRecommendation(request);

            // assert
            Assert.IsNull(recommendation.Place);
            Assert.That(recommendation.Rules, Has.Exactly(0).Items);
        }

        [Test]
        public async Task TestATimeThereIsNoForecastFor()
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
                .Returns(new[] { new Place("", "", "", "Larvik", new Location(59, 0)), });

            mockWeatherForecastService
                .Setup(fs => fs.GetWeatherForecast(It.IsAny<Place>()))
                .ReturnsAsync(new WeatherForecast(new[] {
                    new TemperatureForecast(
                        25,
                        new DateTime(2010, 1, 1, 12, 0, 0),
                        new DateTime(2010, 1, 1, 14, 0, 0)),
                }));

            // act
            var request = new ClothingRecommendationRequest(testPeriod, testLocation);
            var service = new ClothingRecommendationService(mockWeatherForecastService.Object, mockClothingRuleRepository.Object);
            var recommendation = await service.GetClothingRecommendation(request);

            // assert
            Assert.IsNull(recommendation);
            //var exception = Assert.ThrowsAsync<CannotGiveMinOrMaxWithNoNumbersException>(
            //    () => service.GetClothingRecommendation(request));
            //Assert.IsInstanceOf<CannotGiveMinOrMaxWithNoNumbersException>(exception);
            //Assert.That(recommendation.Rules, Has.Exactly(0).Items);
        }

        [Test]
        public async Task TestCreateOrUpdateRule()
        {
            // Arrange  
            var weatherForecastService = new Mock<IWeatherForecastService>();
            var clothingRuleRepository = new Mock<IClothingRuleRepository>();
            var service = new ClothingRecommendationService(weatherForecastService.Object, clothingRuleRepository.Object);

            var guid = new Guid();
            var newRule = new ClothingRule(0, 20, null, "Godt humør", guid);
            var updateRule = new ClothingRule(0, 30, null, "Støvler", guid);

            // Act
            clothingRuleRepository.Setup(crr =>
                crr.Create(It.IsAny<ClothingRule>())).ReturnsAsync(1);
            var isCreatedRule = await service.CreateOrUpdateRule(newRule);

            clothingRuleRepository.Setup(crr =>
                crr.Update(It.IsAny<ClothingRule>())).ReturnsAsync(1);
            var isUpdatedRule = await service.CreateOrUpdateRule(updateRule);

            // Assert
            clothingRuleRepository.Verify(crr => crr.Create(It.Is<ClothingRule>(cr => cr.Clothes == "Godt humør")));
            Assert.IsTrue(isCreatedRule);

            clothingRuleRepository.Verify(crr => crr.Update(It.Is<ClothingRule>(cr => cr.Clothes == "Støvler" && cr.Id.Equals(guid))));
            Assert.IsTrue(isUpdatedRule);
        }

        // [Test]
        // liste over regler. lage en ny regel og prøve å legge til én som ikke er der. da skal Verify at Creeate har kjørt.
        // så prøve å updatere en regel som allerede er i lista, men ikke den som akkurat blei lagt til.
    }
}
