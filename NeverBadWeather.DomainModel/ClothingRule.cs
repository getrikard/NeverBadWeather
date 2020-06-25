using System;
using System.Collections.Generic;
using System.Text;

namespace NeverBadWeather.DomainModel
{
    public class ClothingRule
    {
        public int FromTemperature { get; }
        public int ToTemperature { get; }
        public Clothing Clothing { get; }

        public bool Match(int temperature)
        {
            return temperature > FromTemperature
                   && temperature > ToTemperature;
        }

        public ClothingRule(int fromTemperature, int temperature, Clothing clothing)
        {
            FromTemperature = fromTemperature;
            ToTemperature = temperature;
            Clothing = clothing;
        }
    }
}
