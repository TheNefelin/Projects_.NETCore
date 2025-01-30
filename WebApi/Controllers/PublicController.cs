using ClassLibrary.Common;
using ClassLibrary.GamesGuide.DTOs;
using ClassLibrary.GamesGuide.Interfaces;
using ClassLibrary.GamesGuideDapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/public")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        private readonly ILogger<PublicController> _logger;
        public readonly IPublicService _publicService;
        public readonly PublicDapperService _dapper;

        public PublicController(ILogger<PublicController> logger, IPublicService publicService, PublicDapperService dapper)
        {
            _logger = logger;
            _publicService = publicService;
            _dapper = dapper;
        }

        [HttpGet("ef-games")]
        public async Task<ActionResult<ResponseApi<IEnumerable<DataGameDTO>>>> GetAllEF(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Received request to fetch all games.");
            var result = await _publicService.GetAllGamesAsync(cancellationToken);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("dapper-games")]
        public async Task<ActionResult<ResponseApi<IEnumerable<DataGameDTO>>>> GetAllDapper(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Received request to fetch all games.");
            var result = await _dapper.GetAllAsync("", cancellationToken);

            return StatusCode(result.StatusCode, result);
        }
    }
}
