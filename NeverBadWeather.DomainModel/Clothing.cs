using System;
using System.Collections.Generic;
using System.Text;

namespace NeverBadWeather.DomainModel
{
    public class Clothing
    {
        public string Description {get; }

        public Clothing(string description)
        {
            Description = description;
        }
    }
}
