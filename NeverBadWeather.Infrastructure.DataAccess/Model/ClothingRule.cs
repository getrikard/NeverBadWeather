using System;
using System.Collections.Generic;
using System.Text;

namespace NeverBadWeather.Infrastructure.DataAccess.Model
{
    public class ClothingRule
    {
        public Guid Id;
        public bool IsRaining;
        public int FromTemperature;
        public int ToTemperature;
        public string Clothes;
    }
}
