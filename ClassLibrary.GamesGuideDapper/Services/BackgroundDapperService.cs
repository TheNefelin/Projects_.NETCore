using ClassLibrary.Common.DTOs;
using ClassLibrary.GamesGuideDapper.Interfaces;
using Dapper;
using System.Data;

namespace ClassLibrary.GamesGuideDapper.Services
{
    public class BackgroundDapperService : IServiceCRUD<BackgroundDTO>
    {
        private readonly IDbConnection _dapper;

        public BackgroundDapperService(IDbConnection dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<BackgroundDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _dapper.QueryAsync<BackgroundDTO>(new CommandDefinition(
                    $"GG_Backgrounds_GetAll",
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
