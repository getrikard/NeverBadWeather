using System;
using System.Collections.Generic;
using System.Text;

namespace NeverBadWeather.DomainModel
{
    public class Place
    {
        public string Country { get; }
        public string Region { get; }
        public string City { get; }
        public string Name { get; }

        public Place(string country, string region, string city, string name)
        {
            Country = country;
            Region = region;
            City = city;
            Name = name;
        }
    }
}
