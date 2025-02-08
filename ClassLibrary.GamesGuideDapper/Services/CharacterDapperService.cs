using ClassLibrary.GamesGuideDapper.DTOs;
using ClassLibrary.GamesGuideDapper.Interfaces;
using Dapper;
using System.Data;

namespace ClassLibrary.GamesGuideDapper.Services
{
    public class CharacterDapperService : IServiceCRUD<CharacterDTO>
    {
        private readonly IDbConnection _dapper;

        public CharacterDapperService(IDbConnection dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<CharacterDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var query = "SELECT Id, Name, Description, ImgUrl, Id_Game FROM GG_Characters";
            try
            {
                var result = await _dapper.QueryAsync<CharacterDTO>(query);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error CharacterDapperService.", ex);
            }
        }
    }
}
