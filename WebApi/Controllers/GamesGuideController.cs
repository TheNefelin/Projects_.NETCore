using ClassLibrary.Common;
using ClassLibrary.GamesGuide.DTOs;
using ClassLibrary.GamesGuide.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/games-guide")]
    [ApiController]

    public class GamesGuideController : ControllerBase
    {
        private readonly ILogger<GamesGuideController> _logger;
        public readonly IGamesService _gamesService;

        public GamesGuideController(ILogger<GamesGuideController> logger, IGamesService gamesService)
        {
            _logger = logger;
            _gamesService = gamesService;
        }

        //[HttpGet]
        //public async Task<ActionResult<ResponseApi<IEnumerable<GameDTO>>>> GetAll(CancellationToken cancellationToken)
        //{
        //    _logger.LogInformation("Received request to fetch all games.");
        //    var result = await _gamesService.GetAllAsync(cancellationToken);

        //    return StatusCode(result.StatusCode, result);
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<ResponseApi<GameDTO>>> GetById(int id, CancellationToken cancellationToken)
        //{
        //    _logger.LogInformation("Received request to fetch game by ID: {Id}", id);
        //    var result = await _gamesService.GetByIdAsync(id, cancellationToken);

        //    return StatusCode(result.StatusCode, result);
        //}

        //[HttpPost]
        //public async Task<ActionResult<ResponseApi<GameDTO>>> Create([FromBody] GameDTO newGame, CancellationToken cancellationToken)
        //{
        //    _logger.LogInformation("Received request to create a new game.");
        //    var result = await _gamesService.CreateAsync(newGame, cancellationToken);

        //    return StatusCode(result.StatusCode, result);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult<ResponseApi<GameDTO>>> Update(int id, [FromBody] GameDTO updatedGame, CancellationToken cancellationToken)
        //{
        //    _logger.LogInformation("Received request to update game with ID: {Id}", id);
        //    var result = await _gamesService.UpdateAsync(id, updatedGame, cancellationToken);

        //    return StatusCode(result.StatusCode, result);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<ResponseApi<bool>>> Delete(int id, CancellationToken cancellationToken)
        //{
        //    _logger.LogInformation("Received request to delete game with ID: {Id}", id);
        //    var result = await _gamesService.DeleteAsync(id, cancellationToken);

        //    return StatusCode(result.StatusCode, result);
        //}
    }
}
