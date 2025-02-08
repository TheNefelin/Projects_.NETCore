using ClassLibrary.GamesGuideDapper.DTOs;
using ClassLibrary.GamesGuideDapper.Interfaces;
using Dapper;
using System.Data;

namespace ClassLibrary.GamesGuideDapper.Services
{
    public class BackgroundDapperService : IServiceCRUD<BackgroundDTO>
    {
        private readonly IDbConnection _dapper;

        public BackgroundDapperService(IDbConnection dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<BackgroundDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var query = "SELECT Id, ImgUrl, Id_Game FROM GG_Backgrounds";
            try
            {
                var result = await _dapper.QueryAsync<BackgroundDTO>(query);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error BackgroundDapperService.", ex);
            }
        }
    }
}
