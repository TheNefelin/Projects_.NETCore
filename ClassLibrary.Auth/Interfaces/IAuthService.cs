﻿using ClassLibrary.Auth.DTOs;
using ClassLibrary.Common.Models;

namespace ClassLibrary.Auth.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseApi<AuthLogged>> LoginAsync(AuthLogin login, JwtConfig jwtConfig, CancellationToken cancellationToken);
        Task<ResponseApi<object>> RegisterAsync(AuthRegister register, CancellationToken cancellationToken);
    }
}
