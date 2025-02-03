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
            var query = "SELECT Id, ImgUrl, Sort, Id_Adventure FROM GG_AdventuresImg";
            try
            {
                var result = await _dapper.QueryAsync<AdventureImgDTO>(query);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error AdventureImgDapperService.", ex);
            }
        }
    }
}
