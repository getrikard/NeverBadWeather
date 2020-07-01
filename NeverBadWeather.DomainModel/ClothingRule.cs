﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NeverBadWeather.DomainModel
{
    public class ClothingRule : BaseEntity
    {
        public int FromTemperature { get; }
        public int ToTemperature { get; }
        public bool IsRaining { get; }
        public string Clothing { get; }

        public bool Match(int temperature)
        {
            return temperature > FromTemperature
                   && temperature > ToTemperature;
        }

        public ClothingRule(int fromTemperature, int toTemperature, bool isRaining, string clothing)
        {
            FromTemperature = fromTemperature;
            ToTemperature = toTemperature;
            IsRaining = isRaining;
            Clothing = clothing;
        }

        public ClothingRule(Guid id, int fromTemperature, int toTemperature, bool isRaining, string clothing)
            : base(id)
        {
            FromTemperature = fromTemperature;
            ToTemperature = toTemperature;
            IsRaining = isRaining;
            Clothing = clothing;
        }
    }
}
