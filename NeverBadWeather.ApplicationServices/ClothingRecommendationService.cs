using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeverBadWeather.DomainModel;
using NeverBadWeather.DomainServices;

namespace NeverBadWeather.ApplicationServices
{
    public class ClothingRecommendationService
    {
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly IClothingRuleRepository _clothingRuleRepository;

        public ClothingRecommendationService(
            IWeatherForecastService weatherForecastService,
            IClothingRuleRepository clothingRuleRepository)
        {
            _clothingRuleRepository = clothingRuleRepository;
            _weatherForecastService = weatherForecastService;
        }

        public async Task<IEnumerable<ClothingRule>> GetRules(User user)
        {
            return await _clothingRuleRepository.GetRulesByUser(user?.Id);
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
        public async Task<bool> CreateOrUpdateRule(ClothingRule rule)
        {
            var rowsAffected = await _clothingRuleRepository.Update(rule);
            if (rowsAffected == 0)
            {
                rowsAffected= await _clothingRuleRepository.Create(rule);
            }

            return rowsAffected == 1;
        }
    }
}
