using ClassLibrary.Common.DTOs;
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
                var result = await _dapper.QueryAsync<GuideUserDTO>(new CommandDefinition(
                    $"GG_GuidesUser_GetAll",
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
