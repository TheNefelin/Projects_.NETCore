using ClassLibrary.Common;
using ClassLibrary.GamesGuideDapper.Interfaces;
using Dapper;
using System.Data;

namespace ClassLibrary.GamesGuideDapper.Services
{
    public class ApiKeyService : IApiKeyService
    {
        private readonly IDbConnection _dapper;

        public ApiKeyService(IDbConnection dapper)
        {
            _dapper = dapper;
        }

        public async Task<bool> ValidateApiKey(string apiKey)
        {
            try
            {
                var sqlApiKey = await _dapper.QueryFirstOrDefaultAsync<string>(
                    $"SELECT ApiKey FROM Mae_Config WHERE Id = @Id",
                    new { Id = 1 });

                if (sqlApiKey == null) return false;

                return apiKey.Equals(sqlApiKey);
            }
            catch (Exception ex)
            {
                throw new Exception("Error validating API Key.", ex);
            }
        }
    }
}
