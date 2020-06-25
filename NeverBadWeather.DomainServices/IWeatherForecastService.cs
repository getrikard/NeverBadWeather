using System;
using System.Collections.Generic;
using System.Text;
using NeverBadWeather.DomainModel;

namespace NeverBadWeather.DomainServices
{
    public interface IWeatherForecastService
    {
        WeatherForecast GetWeatherForecast(Place place);
        Place GetPlace(Location location);
    }
}
