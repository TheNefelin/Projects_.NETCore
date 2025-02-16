using ClassLibrary.GamesGuideDapper.Entities;
using ClassLibrary.GamesGuideDapper.Interfaces;
using Dapper;
using System.Data;

namespace ClassLibrary.GamesGuideDapper.Services
{
    public class SourceDapperService : IServiceCRUD<SourceEntity>
    {
        private readonly IDbConnection _dapper;

        public SourceDapperService(IDbConnection dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<SourceEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            var query = "SELECT Id, Name, Url, Id_Game FROM GG_Sources";
            try
            {
                var result = await _dapper.QueryAsync<SourceEntity>(query);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error SourceDapperService.", ex);
            }
        }
    }
}
