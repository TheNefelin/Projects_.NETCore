using ClassLibrary.GamesGuideDapper.Entities;
using ClassLibrary.GamesGuideDapper.Interfaces;
using Dapper;
using System.Data;

namespace ClassLibrary.GamesGuideDapper.Services
{
    public class AdventureImgDapperService : IServiceCRUD<AdventureImgEntity>
    {
        private readonly IDbConnection _dapper;

        public AdventureImgDapperService(IDbConnection dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<AdventureImgEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            var query = "SELECT Id, ImgUrl, Sort, Id_Adventure FROM GG_AdventuresImg";
            try
            {
                var result = await _dapper.QueryAsync<AdventureImgEntity>(query);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error AdventureImgDapperService.", ex);
            }
        }
    }
}
