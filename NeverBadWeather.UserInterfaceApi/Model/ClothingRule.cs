using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeverBadWeather.UserInterfaceApi.Model
{
    public class ClothingRule 
    {
        public Guid Id { get; set; }
        public int FromTemperature { get; set; }
        public int ToTemperature { get; set; }
        public bool IsRaining { get; set; }
        public string Clothes { get; set; }
    }
}
