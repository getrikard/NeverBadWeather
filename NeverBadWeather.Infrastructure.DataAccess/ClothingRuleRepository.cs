using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
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
        public async Task<IEnumerable<DomainClothingRule>> GetRulesByUser(Guid? userId)
        {
            await using var connection = new SqlConnection(_configuration.ConnectionString);
            const string select = @"
                SELECT [Id]
                      ,[IsRaining]
                      ,[FromTemperature]
                      ,[ToTemperature]
                      ,[Clothes]
                      ,[UserId]
                  FROM [dbo].[ClothingRule]
                  WHERE Id = @Id
            ";
            var rules = await connection.QueryAsync<DbClothingRule>(select, new {Id = userId});
            return rules.Select(DomainModelFromDbModel);
        }

        public async Task<int> Create(DomainClothingRule rule)
        {
            await using var connection = new SqlConnection(_configuration.ConnectionString);
            const string update = @"
                INSERT INTO [dbo].[ClothingRule]
                           ([Id]
                           ,[IsRaining]
                           ,[FromTemperature]
                           ,[ToTemperature]
                           ,[Clothes]
                           ,[UserId])
                     VALUES
                           (@Id
                           ,@IsRaining
                           ,@FromTemperature
                           ,@ToTemperature
                           ,@Clothes
                           ,@UserId)
            ";
            var data = DbModelFromDomainModel(rule);
            var rows = await connection.ExecuteAsync(update, data);
            return rows;
        }

        public async Task<int> Update(DomainClothingRule rule)
        {
            await using var connection = new SqlConnection(_configuration.ConnectionString);
            const string update = @"
                UPDATE [dbo].[ClothingRule]
                   SET [Id] = @Id
                      ,[IsRaining] = @IsRaining
                      ,[FromTemperature] = @FromTemperature
                      ,[ToTemperature] = @ToTemperature
                      ,[Clothes] = @Clothes
                 WHERE Id = @Id
            ";
            var data = DbModelFromDomainModel(rule);
            var rows = await connection.ExecuteAsync(update, data);
            return rows;
        }

        public async Task<int> Delete(DomainClothingRule rule)
        {
            await using var connection = new SqlConnection(_configuration.ConnectionString);
            const string update = @"
                DELETE FROM [dbo].[ClothingRule]
                WHERE Id = @Id
            ";
            var data = DbModelFromDomainModel(rule);
            var rows = await connection.ExecuteAsync(update, data);
            return rows;
        }

        private DbClothingRule DbModelFromDomainModel(DomainClothingRule rule)
        {
            return new DbClothingRule { 
                Id = rule.Id,
                FromTemperature = rule.FromTemperature,
                ToTemperature = rule.ToTemperature,
                IsRaining = rule.IsRaining,
                Clothes = rule.Clothes
            };
        }

        private DomainClothingRule DomainModelFromDbModel(DbClothingRule rule)
        {
            return new DomainClothingRule(
                rule.Id,
                rule.FromTemperature,
                rule.ToTemperature,
                rule.IsRaining,
                rule.Clothes
            );
        }
    }
}
