using ClassLibrary.Common.DTOs;
using ClassLibrary.GamesGuideDapper.Interfaces;
using Dapper;
using System.Data;

namespace ClassLibrary.GamesGuideDapper.Services
{
    public class GuideDapperService : IServiceCRUD<GuideDTO>
    {
        private readonly IDbConnection _dapper;

        public GuideDapperService(IDbConnection dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<GuideDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var query = "SELECT Id, Name, Sort, Id_Game FROM GG_Guides";
            try
            {
                var result = await _dapper.QueryAsync<GuideDTO>(query);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error GuideDapperService.", ex);
            }
        }
    }
}
