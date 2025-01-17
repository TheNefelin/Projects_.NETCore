using ClassLibrary.Common;
using ClassLibrary.GamesGuide.DTOs;
using ClassLibrary.GamesGuide.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/public")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        private readonly ILogger<PublicController> _logger;
        public readonly IPublicService _publicService;

        public PublicController(ILogger<PublicController> logger, IPublicService publicService)
        {
            _logger = logger;
            _publicService = publicService;
        }

        [HttpGet("games")]
        public async Task<ActionResult<ResponseApi<IEnumerable<DataGameDTO>>>> GetAll(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Received request to fetch all games.");
            var result = await _publicService.GetAllGamesAsync(cancellationToken);

            return StatusCode(result.StatusCode, result);
        }
    }
}
