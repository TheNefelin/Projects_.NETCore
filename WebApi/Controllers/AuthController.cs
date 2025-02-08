using ClassLibrary.Common;
using ClassLibrary.Common.Services;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [ServiceFilter(typeof(ApiKeyFilter))]
    public class AuthController : ControllerBase
    {
        private readonly AuthGoogleService _authService;

        public AuthController(AuthGoogleService authService)
        {
            _authService = authService;
        }

        [HttpPost("google")]
        public async Task<ActionResult<ResponseApi<LoggedGoogleToken>>> GoogleLoginAsync(LoginGoogle login, CancellationToken cancellationToken)
        {
            var result = await _authService.LoginGoogleAsync(login, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
