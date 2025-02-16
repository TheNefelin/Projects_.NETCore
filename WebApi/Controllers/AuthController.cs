using ClassLibrary.Auth.DTOs;
using ClassLibrary.Auth.Interfaces;
using ClassLibrary.Common.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration configuration, IAuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        [HttpGet]
        public string GetApiKey()
        {
            Request.Headers.TryGetValue("ApiKey", out var apiKey);
            return apiKey;
        }

        //[ServiceFilter(typeof(ApiKeyFilter))]
        [HttpPost("register")]
        public async Task<ActionResult<ResponseApi<object>>> Register(AuthRegister register, CancellationToken cancellationToken)
        {
            var response = await _authService.RegisterAsync(register, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        //[ServiceFilter(typeof(ApiKeyFilter))]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<ResponseApi<AuthLogged>>> Login(AuthLogin login, CancellationToken cancellationToken)
        {
            var jwtConfig = new JwtConfig()
            {
                Key = _configuration["Jwt:Key"]!,
                Issuer = _configuration["Jwt:Issuer"]!,
                Audience = _configuration["Jwt:Audience"]!,
                Subject = _configuration["JWT:Subject"]!,
                ExpireMin = _configuration["JWT:ExpireMin"]!
            };

            var response = await _authService.LoginAsync(login, jwtConfig, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
