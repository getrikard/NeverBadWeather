using System;
using System.Collections.Generic;
using System.Text;
using NeverBadWeather.DomainModel;

namespace NeverBadWeather.DomainServices
{
    public interface IClothingRuleRepository
    {
        IEnumerable<ClothingRule> GetRules(User user);
    }
}
