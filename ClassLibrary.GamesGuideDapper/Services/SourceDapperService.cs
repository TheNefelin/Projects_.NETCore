using ClassLibrary.GamesGuideDapper.DTOs;
using ClassLibrary.GamesGuideDapper.Interfaces;
using Dapper;
using System.Data;

namespace ClassLibrary.GamesGuideDapper.Services
{
    public class SourceDapperService : IServiceCRUD<SourceDTO>
    {
        private readonly IDbConnection _dapper;

        public SourceDapperService(IDbConnection dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<SourceDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var query = "SELECT Id, Name, Url, Id_Game FROM GG_Sources";
            try
            {
                var result = await _dapper.QueryAsync<SourceDTO>(query);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error SourceDapperService.", ex);
            }
        }
    }
}
