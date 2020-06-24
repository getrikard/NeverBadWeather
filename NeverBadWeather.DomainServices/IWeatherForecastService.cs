using System;
using System.Collections.Generic;
using System.Text;
using NeverBadWeather.DomainModel;

namespace NeverBadWeather.DomainServices
{
    public interface IWeatherForecastService
    {
        WeatherForecast GetWeatherForecast(Location location);
    }
}
