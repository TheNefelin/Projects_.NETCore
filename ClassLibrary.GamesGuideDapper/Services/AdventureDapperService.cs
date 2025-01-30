using ClassLibrary.Common.DTOs;
using ClassLibrary.GamesGuideDapper.Interfaces;
using Dapper;
using System.Data;

namespace ClassLibrary.GamesGuideDapper.Services
{
    public class AdventureDapperService :IServiceCRUD<AdventureDTO>
    {
        private readonly IDbConnection _dapper;

        public AdventureDapperService(IDbConnection dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<AdventureDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _dapper.QueryAsync<AdventureDTO>(new CommandDefinition(
                    $"GG_Adventures_GetAll",
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
