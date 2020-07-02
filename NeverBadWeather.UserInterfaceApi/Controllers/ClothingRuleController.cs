using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeverBadWeather.ApplicationServices;
using NeverBadWeather.UserInterfaceApi.Model;

namespace NeverBadWeather.UserInterfaceApi.Controllers
{
    public class ClothingRuleController : Controller
    {
        private readonly ClothingRecommendationService _service;

        public ClothingRuleController(ClothingRecommendationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ClothingRecommendation>> GetAll()
        {
            var rules = await _service.GetRules(null);
            return rules.Select()

        }
    }
}
