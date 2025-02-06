
using ClassLibrary.Common;
using ClassLibrary.PortfolioDapper.Models.DTOs;
using ClassLibrary.PortfolioDapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/portfolio")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly PortfolioService _portfolioService;

        public PortfolioController(PortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet("projects")]
        public async Task<ActionResult<ResponseApi<IEnumerable<DataProjectDTO>>>> GetAllProjects(CancellationToken cancellationToken) {
            var res = await _portfolioService.GetAll_Projects_Async(cancellationToken);
            return StatusCode(res.StatusCode, res);
        }

        [HttpGet("urls")]
        public async Task<ActionResult<ResponseApi<IEnumerable<DataUrlGrpDTO>>>> GetAllUrls(CancellationToken cancellationToken)
        {
            var res = await _portfolioService.GetAll_Urls_Async(cancellationToken);
            return StatusCode(res.StatusCode, res);
        }

    }
}