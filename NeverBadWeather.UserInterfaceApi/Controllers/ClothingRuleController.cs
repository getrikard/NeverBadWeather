using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeverBadWeather.ApplicationServices;
using NeverBadWeather.UserInterfaceApi.Model;

namespace NeverBadWeather.UserInterfaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothingRuleController : Controller
    {
        private readonly ClothingRecommendationService _service;

        public ClothingRuleController(ClothingRecommendationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClothingRule>>> GetAll()
        {
            var rulesDomain = await _service.GetRules(null);
            var rulesViewModel = rulesDomain.Select(ViewModelFromDomainModel);
            return Ok(rulesViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateOrUpdate(ClothingRule clothingRule)
        {
            var ruleDomain = DomainModelFromViewModel(clothingRule);
            var result = await _service.CreateOrUpdateRule(ruleDomain);
            return Ok(result);
        }

        private DomainModel.ClothingRule DomainModelFromViewModel(ClothingRule rule)
        {
            return new DomainModel.ClothingRule(
                rule.FromTemperature,
                rule.ToTemperature,
                rule.IsRaining,
                rule.Clothes,
                rule.Id
                );
        }

        private ClothingRule ViewModelFromDomainModel(DomainModel.ClothingRule rule)
        {
            return new ClothingRule
            {
                Id = rule.Id,
                IsRaining = rule.IsRaining,
                Clothes = rule.Clothes,
                ToTemperature = rule.ToTemperature,
                FromTemperature = rule.FromTemperature
            };
        }
    }
}
