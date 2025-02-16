using ClassLibrary.GamesGuideDapper.Entities;
using ClassLibrary.GamesGuideDapper.Interfaces;
using Dapper;
using System.Data;

namespace ClassLibrary.GamesGuideDapper.Services
{
    public class GuideDapperService : IServiceCRUD<GuideEntity>
    {
        private readonly IDbConnection _dapper;

        public GuideDapperService(IDbConnection dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<GuideEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            var query = "SELECT Id, Name, Sort, Id_Game FROM GG_Guides";
            try
            {
                var result = await _dapper.QueryAsync<GuideEntity>(query);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error GuideDapperService.", ex);
            }
        }
    }
}
