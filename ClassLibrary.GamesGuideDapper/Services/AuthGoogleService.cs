using ClassLibrary.Common;
using ClassLibrary.Common.DTOs;
using Dapper;
using System.Data;

namespace ClassLibrary.GamesGuideDapper.Services
{
    public class AuthGoogleService
    {
        private readonly IDbConnection _connection;

        public AuthGoogleService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<ResponseApi<LoggedGoogleTokenDTO>> LoginGoogleAsync(LoginGoogleDTO login, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _connection.QueryFirstAsync<LoggedGoogleDTO>(new CommandDefinition(
                    $"GG_Login",
                    new { login.Email, login.Sub, login.Jti },
                    commandType: CommandType.StoredProcedure,
                    transaction: default,
                    cancellationToken: cancellationToken));

                return new ResponseApi<LoggedGoogleTokenDTO> { 
                    IsSucces =  result.IsSucces,
                    StatusCode = result.StatusCode,
                    Message = result.Msge,
                    Data = new LoggedGoogleTokenDTO { 
                        Id = result.Id, 
                        SqlToken = result.SqlToken 
                    }
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la conexión o transacción.", ex);
            }
        }
    }
}
