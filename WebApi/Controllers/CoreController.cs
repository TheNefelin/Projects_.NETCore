using ClassLibrary.Common.Models;
using ClassLibrary.PasswordManagerDapper.DTOs;
using ClassLibrary.PasswordManagerDapper.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/core")]
    [ApiController]
    [Authorize]
    [ServiceFilter(typeof(ApiKeyFilter))]
    public class CoreController : ControllerBase
    {
        private readonly ICoreService _coreService;

        public CoreController(ICoreService coreService)
        {
            _coreService = coreService;
        }

        [HttpPatch("register")]
        public async Task<ActionResult<ResponseApi<CoreIVDTO>>> Register(CoreRequestDTO<object> request, CancellationToken cancellationToken)
        {
            var response = await _coreService.RegisterAsync(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPatch("get-iv")]
        public async Task<ActionResult<ResponseApi<CoreIVDTO>>> GetIV(CoreRequestDTO<object> request, CancellationToken cancellationToken)
        {
            var response = await _coreService.GetIVAsync(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPatch("get-all")]
        public async Task<ActionResult<ResponseApi<IEnumerable<CoreDTO>>>> GetAll(CoreRequestDTO<object> request, CancellationToken cancellationToken)
        {
            var response = await _coreService.GetAllAsync(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPatch("get-byid")]
        public async Task<ActionResult<ResponseApi<CoreDTO>>> GetById(CoreRequestDTO<CoreDTO> request, CancellationToken cancellationToken)
        {
            var response = await _coreService.GetByIdAsync(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPatch("insert")]
        public async Task<ActionResult<ResponseApi<CoreDTO>>> Insert(CoreRequestDTO<CoreDTO> request, CancellationToken cancellationToken)
        {
            var response = await _coreService.InsertAsync(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPatch("update")]
        public async Task<ActionResult<ResponseApi<CoreDTO>>> Update(CoreRequestDTO<CoreDTO> request, CancellationToken cancellationToken)
        {
            var response = await _coreService.UpdateAsync(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPatch("delete")]
        public async Task<ActionResult<ResponseApi<object>>> Delete(CoreRequestDTO<CoreDTO> request, CancellationToken cancellationToken)
        {
            var response = await _coreService.DeleteAsync(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
