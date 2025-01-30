
using ClassLibrary.Common.DTOs;
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
            try
            {
                var result = await _dapper.QueryAsync<GameDTO>(new CommandDefinition(
                    $"GG_Games_GetAll",
                    commandType: CommandType.StoredProcedure,
                    transaction: default,
                    cancellationToken: cancellationToken));

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
