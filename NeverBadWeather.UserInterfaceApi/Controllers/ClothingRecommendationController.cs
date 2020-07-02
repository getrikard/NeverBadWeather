using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeverBadWeather.ApplicationServices;
using NeverBadWeather.UserInterfaceApi.Model;

namespace NeverBadWeather.UserInterfaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothingRecommendationController : ControllerBase
    {
        private readonly ClothingRecommendationService _service;

        public ClothingRecommendationController(ClothingRecommendationService service)
        {
            _service = service;
        }

    }
}
