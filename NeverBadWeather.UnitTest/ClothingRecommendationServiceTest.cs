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
        public void TestNoRules()
        {
            var mockWeatherForecast = new Mock<IWeatherForecastService>();
            var mockClothingRule = new Mock<IClothingRuleRepository>();

            var service = new ClothingRecommendationService(
                mockWeatherForecast.Object, 
                mockClothingRule.Object);
            var recommendation = service.GetClothingRecommendation(new User(), new Location());

            Assert.IsNull(recommendation);
        }

        [Test]
        public void TestOneRule1()
        {
            // arrange
            var mockWeatherForecast = new Mock<IWeatherForecastService>();
            var mockClothingRule = new Mock<IClothingRuleRepository>();
            mockClothingRule.Setup(m=>m.GetRules(It.IsAny<User>()))
                .Returns(
                    new []
                    {
                        new ClothingRule(
                            10, 
                            20, 
                            new Clothing("Shorts og t-skjorte")),
                    });
            mockWeatherForecast.Setup(m => m.GetPlace(It.IsAny<Location>()))
                .Returns(new Place());
            mockWeatherForecast.Setup(m=>m.GetWeatherForecast(It.IsAny<Place>()))
                .Returns(new WeatherForecast(15));
                

            // act
            var service = new ClothingRecommendationService(
                mockWeatherForecast.Object,
                mockClothingRule.Object);
            var recommendation = service.GetClothingRecommendation(new User(), new Location());

            // assert
            Assert.AreEqual("Shorts og t-skjorte", recommendation.Description);
        }
    }
}