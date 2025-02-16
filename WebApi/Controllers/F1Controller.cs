using ClassLibrary.Common.Models;
using ClassLibrary.F1Dapper.DTOs;
using ClassLibrary.F1Dapper.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/f1")]
    [ApiController]
    //[ServiceFilter(typeof(ApiKeyFilter))]
    public class F1Controller : ControllerBase
    {
        private readonly ILogger<F1Controller> _logger;
        private readonly IF1Service _service;

        public F1Controller(ILogger<F1Controller> logger, IF1Service service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("teams")]
        public async Task<ActionResult<ResponseApi<IEnumerable<TeamDTO>>>> GetAllTeams(CancellationToken cancellationToken) {
            _logger.LogInformation("Received request to fetch all Flags.");
            var result = await _service.GetAll_Teams_Async(cancellationToken);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("pilots")]
        public async Task<ActionResult<ResponseApi<IEnumerable<PilotDTO>>>> GetAllPilots(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Received request to fetch all Pilots.");
            var result = await _service.GetAll_Pilots_Async(cancellationToken);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("circuits")]
        public async Task<ActionResult<ResponseApi<IEnumerable<CircuitDTO>>>> GetAllCircuits(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Received request to fetch all Circuits.");
            var result = await _service.GetAll_Circuits_Async(cancellationToken);

            return StatusCode(result.StatusCode, result);
        }
    }
}
