using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace NeverBadWeather.DomainModel
{
    public class ClothingRule : BaseEntity
    {
        public int FromTemperature { get; }
        public int ToTemperature { get; }
        public bool? IsRaining { get; }
        public string Clothes { get; }

        public bool Match(int temperature)
        {
            return temperature > FromTemperature
                   && temperature > ToTemperature;
        }

        public ClothingRule(int fromTemperature, int toTemperature, bool? isRaining, string clothes, Guid? id = null)
            : base(id)
        {
            FromTemperature = fromTemperature;
            ToTemperature = toTemperature;
            IsRaining = isRaining;
            Clothes = clothes;
        }
    }
}
