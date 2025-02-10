using ClassLibrary.Common;
using ClassLibrary.Common.DTOs;
using ClassLibrary.GamesGuide.Interfaces;
using ClassLibrary.GamesGuideDapper.DTOs;
using ClassLibrary.GamesGuideDapper.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/game-guide")]
    [ApiController]
    [ServiceFilter(typeof(ApiKeyFilter))]
    public class GameGuideController : ControllerBase
    {
        private readonly ILogger<GameGuideController> _logger;
        public readonly IGameGuideEFService _publicService;
        public readonly IGameGuideDapperService _dapper;
        public readonly IServiceUserCRUD<GuideUserDTO> _guideUser;
        public readonly IServiceUserCRUD<AdventureUserDTO> _adventureUser;

        public GameGuideController(
            ILogger<GameGuideController> logger,
            IGameGuideEFService publicService,
            IServiceUserCRUD<GuideUserDTO> guideUser,
            IServiceUserCRUD<AdventureUserDTO> adventureUser,
            IGameGuideDapperService dapper)
        {
            _logger = logger;
            _publicService = publicService;
            _guideUser = guideUser;
            _adventureUser = adventureUser;
            _dapper = dapper;
        }

        [HttpGet("ef")]
        public async Task<ActionResult<ResponseApi<IEnumerable<DataGameDTO>>>> GetAllEF(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Received request to fetch all games.");
            var result = await _publicService.GetAllGamesAsync(cancellationToken);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("dapper/{iduser?}")]
        public async Task<ActionResult<ResponseApi<IEnumerable<DataGameDTO>>>> GetAllDapper(string? iduser, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Received request to fetch all games.");
            var result = await _dapper.GetAllAsync(iduser, cancellationToken);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("guide")]
        public async Task<ActionResult<ResponseApi<object>>> PostGameDapper(GuideUserDTO gameUser, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Received request to Check Guide.");
            var result = await _guideUser.UpdateAsync(gameUser, cancellationToken);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("adventure")]
        public async Task<ActionResult<ResponseApi<object>>> PostAdventureDapper(AdventureUserDTO adventureUser, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Received request to Check Adventure.");
            var result = await _adventureUser.UpdateAsync(adventureUser, cancellationToken);

            return StatusCode(result.StatusCode, result);
        }
    }
}
