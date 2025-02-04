using ClassLibrary.Common;
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
                var result = await _dapper.QueryAsync<AdventureUserDTO>(
                    $"SELECT Id_Adventure, Id_User, IsCheck FROM GG_AdventuresUser WHERE Id_User = @Id_User",
                    new { Id_User }
                );

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error AdventureUserDapperService.", ex);
            }
        }

        public async Task<ResponseApi<object>> UpdateAsync(AdventureUserDTO guideUser, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _dapper.QueryFirstOrDefaultAsync<ResponseSql>(new CommandDefinition(
                    $"GG_AdventuresUser_Set",
                    new { guideUser.Id_Adventure, guideUser.Id_User, guideUser.IsCheck },
                    commandType: CommandType.StoredProcedure,
                    transaction: default,
                    cancellationToken: cancellationToken));

                return new ResponseApi<object>
                {
                    IsSucces = result.IsSucces,
                    StatusCode = result.StatusCode,
                    Message = result.Msge,
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error AdventureUserDapperService.", ex);
            }
        }
    }
}
