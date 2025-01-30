using ClassLibrary.Common.DTOs;
using ClassLibrary.GamesGuideDapper.Interfaces;
using Dapper;
using System.Data;

namespace ClassLibrary.GamesGuideDapper.Services
{
    public class AdventureImgDapperService : IServiceCRUD<AdventureImgDTO>
    {
        private readonly IDbConnection _dapper;

        public AdventureImgDapperService(IDbConnection dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<AdventureImgDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _dapper.QueryAsync<AdventureImgDTO>(new CommandDefinition(
                    $"GG_AdventuresImg_GetAll",
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
