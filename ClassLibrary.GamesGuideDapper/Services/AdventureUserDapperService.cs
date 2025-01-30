using ClassLibrary.Common.DTOs;
using ClassLibrary.GamesGuideDapper.Interfaces;
using Dapper;
using System.Data;

namespace ClassLibrary.GamesGuideDapper.Services
{
    public class AdventureUserDapperService : IServiceUserCRUD<AdventureUserDTO>
    {
        private readonly IDbConnection _dapper;

        public AdventureUserDapperService(IDbConnection dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<AdventureUserDTO>> GetAllByIdAsync(string Id_User, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _dapper.QueryAsync<AdventureUserDTO>(new CommandDefinition(
                    $"GG_AdventuresUser_GetAll",
                    new { Id_User },
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
