using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using NeverBadWeather.DomainModel;
using DomainClothingRule = NeverBadWeather.DomainModel.ClothingRule;
using DbClothingRule = NeverBadWeather.Infrastructure.DataAccess.Model.ClothingRule;
using NeverBadWeather.DomainServices;

namespace NeverBadWeather.Infrastructure.DataAccess
{
    public class ClothingRuleRepository : IClothingRuleRepository
    {
        private readonly IAppConfiguration _configuration;

        public ClothingRuleRepository(IAppConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<DomainClothingRule>> GetRulesByUser(Guid userId)
        {
            await using var connection = new SqlConnection(_configuration.ConnectionString);
            return Enumerable.Empty<DomainClothingRule>();
        }

        private DomainClothingRule DomainModelFromDbModel(DbClothingRule rule)
        {
            return null;
            //return new DomainClothingRule(
            //    rule.Id,
            //    rule.FromTemperature,
            //    rule.ToTemperature,
            //    rule.IsRaining, 
            //    rule.Clothes
            //);
        }
    }
}
