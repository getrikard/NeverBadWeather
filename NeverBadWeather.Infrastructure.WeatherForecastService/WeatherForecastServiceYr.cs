using System;
using System.Collections.Generic;
using System.Linq;
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
            throw new NotImplementedException();
        }

        public IEnumerable<Place> GetAllPlaces()
        {
            var lines = Resources.noreg.Split(Environment.NewLine).Skip(1);
            return lines.Select(PlaceFromCsvLine).ToList();
        }

        private static Place PlaceFromCsvLine(string line)
        {
            var fields = line.Split('\t');
            var location = new Location(fields[8], fields[9]);
            return new Place("Norge", fields[7], fields[6], fields[1], location);
        }
    }
}
