using System;
using System.Collections.Generic;
using System.Text;
using NeverBadWeather.DomainModel;
using NeverBadWeather.DomainServices;

namespace NeverBadWeather.Infrastructure.WeatherForecastService
{
    public class WeatherForecastServiceYr : IWeatherForecastService
    {
        public WeatherForecast GetWeatherForecast(Place place)
        {
            throw new NotImplementedException();
        }

        public Place GetPlace(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
