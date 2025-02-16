using ClassLibrary.GamesGuideDapper.Entities;
using ClassLibrary.GamesGuideDapper.Interfaces;
using Dapper;
using System.Data;

namespace ClassLibrary.GamesGuideDapper.Services
{
    public class GameDapperService : IServiceCRUD<GameEntity>
    {
        private readonly IDbConnection _dapper;

        public GameDapperService(IDbConnection dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<GameEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            var query = "SELECT Id, Name, Description, ImgUrl, IsActive FROM GG_Games";
            try
            {
                var result = await _dapper.QueryAsync<GameEntity>(query);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error GameDapperService.", ex);
            }
        }
    }
}
