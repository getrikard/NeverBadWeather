using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeverBadWeather.DomainModel;
using NeverBadWeather.DomainServices;

namespace NeverBadWeather.ApplicationServices
{
    public class ClothingRecommendationService
    {
        private IWeatherForecastService _weatherForecastService;
        private IClothingRuleRepository _clothingRuleRepository;

        public ClothingRecommendationService(
            IWeatherForecastService weatherForecastService,
            IClothingRuleRepository clothingRuleRepository)
        {
            _clothingRuleRepository = clothingRuleRepository;
            _weatherForecastService = weatherForecastService;
        }

        //public Clothes GetClothingRecommendation(User user, Location location)
        //{
        //    var rules = _clothingRuleRepository.GetRulesByUser(user);
        //    if (rules == null || !rules.Any()) return null;
        //    var place = _weatherForecastService.GetPlace(location);
        //    var weatherForecast = _weatherForecastService.GetWeatherForecast(place);
        //    foreach (var rule in rules)
        //    {
        //        if(rule.Match(weatherForecast.Temperature))
        //        {
        //            return rule.Clothes;
        //        }
        //    }
        //    return rules.First().Clothes;
        //}
    }
}
