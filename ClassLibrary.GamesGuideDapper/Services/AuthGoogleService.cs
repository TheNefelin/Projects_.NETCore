using ClassLibrary.Common.Models;
using ClassLibrary.GamesGuideDapper.DTOs;
using ClassLibrary.GamesGuideDapper.Interfaces;
using Dapper;
using System.Data;

namespace ClassLibrary.GamesGuideDapper.Services
{
    public class AuthGoogleService : IAuthGoogleService
    {
        private readonly IDbConnection _connection;

        public AuthGoogleService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<ResponseApi<LoggedToken>> LoginGoogleAsync(LoginGoogle login, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _connection.QueryFirstAsync<LoggedGoogle>(new CommandDefinition(
                    $"GG_Login",
                    new { login.Email, login.Sub, login.Jti },
                    commandType: CommandType.StoredProcedure,
                    transaction: default,
                    cancellationToken: cancellationToken));

                return new ResponseApi<LoggedToken>
                {
                    IsSucces = result.IsSucces,
                    StatusCode = result.StatusCode,
                    Message = result.Msge,
                    Data = new LoggedToken
                    {
                        IdUser = result.Id,
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