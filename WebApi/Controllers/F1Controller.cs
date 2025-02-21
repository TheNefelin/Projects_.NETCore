using ClassLibrary.Common.Models;
using ClassLibrary.F1Dapper.DTOs;
using ClassLibrary.F1Dapper.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/f1")]
    [ApiController]
    [ServiceFilter(typeof(ApiKeyFilter))]
    public class F1Controller : ControllerBase
    {
        private readonly ILogger<F1Controller> _logger;
        private readonly IF1Service _service;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public F1Controller(ILogger<F1Controller> logger, IF1Service service, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _service = service;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("img")]
        public IActionResult GetImg(string fileName)
        {
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "F1");
            var filePath = Path.Combine(path, fileName);

            if (System.IO.File.Exists(filePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);

                return File(b, "image/webp");
            }

            return BadRequest(new { Msge = "El Archivo No Existe" });
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
