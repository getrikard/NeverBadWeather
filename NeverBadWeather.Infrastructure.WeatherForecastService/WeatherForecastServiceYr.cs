using System;
using System.Collections.Generic;
using System.Text;
using NeverBadWeather.DomainModel;
using NeverBadWeather.DomainServices;
using NeverBadWeather.Infrastructure.WeatherForecastService.Properties;

namespace NeverBadWeather.Infrastructure.WeatherForecastService
{
    public class WeatherForecastServiceYr : IWeatherForecastService
    {
        static WeatherForecastServiceYr()
        {

        }

        public WeatherForecast GetWeatherForecast(Place place)
        {
            throw new NotImplementedException();
        }

        public Place GetPlace(Location location)
        {
            //Resources.noreg
            throw new NotImplementedException();
        }
    }
}
