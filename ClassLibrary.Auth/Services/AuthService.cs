using ClassLibrary.Auth.DTOs;
using ClassLibrary.Auth.Interfaces;
using ClassLibrary.Common.Models;
using ClassLibrary.Common.Utils;
using Dapper;
using System.Data;

namespace ClassLibrary.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly IDbConnection _connection;
        private readonly PasswordUtil _passwordUtil;
        private readonly JwtTokenUtil _jwtUtil;

        public AuthService(IDbConnection connection)
        {
            _connection = connection;
            _passwordUtil = new PasswordUtil();
            _jwtUtil = new JwtTokenUtil();
        }

        public async Task<ResponseApi<object>> RegisterAsync(AuthRegister register, CancellationToken cancellationToken)
        {
            if (!register.Password1.Equals(register.Password2))
                return new ResponseApi<object>
                {
                    IsSucces = false,
                    StatusCode = 400,
                    Message = "Las contraseñas no Coinciden.",
                };

            var (hash, salt) = _passwordUtil.HashPassword(register.Password1);

            try
            {
                var result = await _connection.QueryFirstAsync<ResponseSql>(
                    new CommandDefinition(
                        $"Auth_Register",
                        new { Id = Guid.NewGuid().ToString(), register.Email, HashLogin = hash, SaltLogin = salt },
                        commandType: CommandType.StoredProcedure,
                        transaction: default,
                        cancellationToken: cancellationToken
                    )
                );

                return new ResponseApi<object>
                {
                    IsSucces = result.IsSucces,
                    StatusCode = result.StatusCode,
                    Message = result.Msge,
                };
            }
            catch (Exception ex)
            {
                return new ResponseApi<object>
                {
                    IsSucces = false,
                    StatusCode = 500,
                    Message = "Error en la operación de base de datos: " + ex.Message
                };
            }
        }

        public async Task<ResponseApi<AuthLogged>> LoginAsync(AuthLogin login, JwtConfig jwtConfig, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _connection.QueryFirstOrDefaultAsync<AuthUser>(
                    new CommandDefinition(
                        $"Auth_Login",
                        new { login.Email },
                        commandType: CommandType.StoredProcedure,
                        transaction: default,
                        cancellationToken: cancellationToken
                ));

                if (user == null)
                    return new ResponseApi<AuthLogged>
                    {
                        IsSucces = false,
                        StatusCode = 401,
                        Message = "Usuario o Contraseña Incorrecta."
                    };

                bool passwordCorrect = _passwordUtil.VerifyPassword(login.Password, user.HashLogin, user.SaltLogin);

                if (!passwordCorrect)
                    return new ResponseApi<AuthLogged>
                    {
                        IsSucces = false,
                        StatusCode = 401,
                        Message = "Usuario o Contraseña Incorrecta."
                    };

                var jwtUser = new JwtUser
                {
                    Id = user.Id,
                    Email = user.Email,
                    Role = user.Role,
                };

                var token = _jwtUtil.GenerateJwtToken(jwtUser, jwtConfig);

                var logged = new AuthLogged()
                {
                    Id = user.Id,
                    SqlToken = user.SqlToken,
                    Role = user.Role,
                    ExpireMin = jwtConfig.ExpireMin,
                    ApiToken = token
                };

                return new ResponseApi<AuthLogged>
                {
                    IsSucces = true,
                    StatusCode = 200,
                    Message = "Autenticación Exitosa.",
                    Data = logged
                };
            }
            catch (Exception ex)
            {
                return new ResponseApi<AuthLogged>
                {
                    IsSucces = false,
                    StatusCode = 500,
                    Message = "Error al Iniciar Sesion: " + ex.Message
                };
            }
        }
    }
}
