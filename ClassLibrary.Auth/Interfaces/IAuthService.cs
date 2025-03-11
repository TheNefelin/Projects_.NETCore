using ClassLibrary.Auth.DTOs;
using ClassLibrary.Common.Models;

namespace ClassLibrary.Auth.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseApi<UserIdDTO>> RegisterAsync(AuthRegister register, CancellationToken cancellationToken);
        Task<ResponseApi<AuthLogged>> LoginAsync(AuthLogin login, JwtConfig jwtConfig, CancellationToken cancellationToken);
    }
}
