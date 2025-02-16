using ClassLibrary.GamesGuideDapper.Entities;
using ClassLibrary.GamesGuideDapper.Interfaces;
using Dapper;
using System.Data;

namespace ClassLibrary.GamesGuideDapper.Services
{
    public class BackgroundDapperService : IServiceCRUD<BackgroundEntity>
    {
        private readonly IDbConnection _dapper;

        public BackgroundDapperService(IDbConnection dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<BackgroundEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            var query = "SELECT Id, ImgUrl, Id_Game FROM GG_Backgrounds";
            try
            {
                var result = await _dapper.QueryAsync<BackgroundEntity>(query);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error BackgroundDapperService.", ex);
            }
        }
    }
}
