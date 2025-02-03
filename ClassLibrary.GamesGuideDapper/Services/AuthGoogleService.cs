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

        public async Task<ResponseLoggedGoogle> LoginGoogleAsync(LoginGoogleDTO login, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _connection.QueryFirstAsync<ResponseLoggedGoogle>(new CommandDefinition(
                    $"GG_Login",
                    new { login.Email, login.Sub, login.Jti },
                    commandType: CommandType.StoredProcedure,
                    transaction: default,
                    cancellationToken: cancellationToken));

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la conexión o transacción.", ex);
            }
        }
    }
}
