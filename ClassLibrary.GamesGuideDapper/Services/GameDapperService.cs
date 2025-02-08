
using ClassLibrary.GamesGuideDapper.DTOs;
using ClassLibrary.GamesGuideDapper.Interfaces;
using Dapper;
using System.Data;

namespace ClassLibrary.GamesGuideDapper.Services
{
    public class GameDapperService : IServiceCRUD<GameDTO>
    {
        private readonly IDbConnection _dapper;

        public GameDapperService(IDbConnection dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<GameDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var query = "SELECT Id, Name, Description, ImgUrl, IsActive FROM GG_Games";
            try
            {
                var result = await _dapper.QueryAsync<GameDTO>(query);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error GameDapperService.", ex);
            }
        }
    }
}
