using ClassLibrary.GamesGuideDapper.DTOs;
using ClassLibrary.GamesGuideDapper.Interfaces;
using Dapper;
using System.Data;

namespace ClassLibrary.GamesGuideDapper.Services
{
    public class AdventureDapperService :IServiceCRUD<AdventureDTO>
    {
        private readonly IDbConnection _dapper;

        public AdventureDapperService(IDbConnection dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<AdventureDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var query = "SELECT Id, Description, IsImportant, Sort, Id_Guide FROM GG_Adventures";
            try
            {
                var result = await _dapper.QueryAsync<AdventureDTO>(query);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error AdventureDapperService.", ex);
            }
        }
    }
}
