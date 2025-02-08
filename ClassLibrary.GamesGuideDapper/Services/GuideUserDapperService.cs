using ClassLibrary.Common;
using ClassLibrary.GamesGuideDapper.DTOs;
using ClassLibrary.GamesGuideDapper.Interfaces;
using Dapper;
using System.Data;

namespace ClassLibrary.GamesGuideDapper.Services
{
    public class GuideUserDapperService : IServiceUserCRUD<GuideUserDTO>
    {
        private readonly IDbConnection _dapper;

        public GuideUserDapperService(IDbConnection dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<GuideUserDTO>> GetAllByIdAsync(string Id_User, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _dapper.QueryAsync<GuideUserDTO>(
                    $"SELECT Id_Guide, Id_User, IsCheck FROM GG_GuidesUser WHERE Id_User = @Id_User",
                    new { Id_User }
                );

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error GuideUserDapperService.", ex);
            }
        }

        public async Task<ResponseApi<object>> UpdateAsync(GuideUserDTO guideUser, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _dapper.QueryFirstAsync<ResponseSql>(new CommandDefinition(
                    $"GG_GuidesUser_Set",
                    new { guideUser.Id_Guide, guideUser.Id_User, guideUser.IsCheck },
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
                throw new Exception("Error GuideUserDapperService.", ex);
            }
        }
    }
}
