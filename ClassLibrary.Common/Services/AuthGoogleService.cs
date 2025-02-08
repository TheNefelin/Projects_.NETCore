using Dapper;
using System.Data;

namespace ClassLibrary.Common.Services
{
    public class AuthGoogleService
    {
        private readonly IDbConnection _connection;

        public AuthGoogleService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<ResponseApi<LoggedGoogleToken>> LoginGoogleAsync(LoginGoogle login, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _connection.QueryFirstAsync<LoggedGoogle>(new CommandDefinition(
                    $"GG_Login",
                    new { login.Email, login.Sub, login.Jti },
                    commandType: CommandType.StoredProcedure,
                    transaction: default,
                    cancellationToken: cancellationToken));

                return new ResponseApi<LoggedGoogleToken>
                {
                    IsSucces = result.IsSucces,
                    StatusCode = result.StatusCode,
                    Message = result.Msge,
                    Data = new LoggedGoogleToken
                    {
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
