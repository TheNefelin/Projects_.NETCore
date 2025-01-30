using ClassLibrary.Common.DTOs;
using ClassLibrary.GamesGuideDapper.Interfaces;
using Dapper;
using System.Data;

namespace ClassLibrary.GamesGuideDapper.Services
{
    public class CharacterDapperService : IServiceCRUD<CharacterDTO>
    {
        private readonly IDbConnection _dapper;

        public CharacterDapperService(IDbConnection dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<CharacterDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _dapper.QueryAsync<CharacterDTO>(new CommandDefinition(
                    $"GG_Characters_GetAll",
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
