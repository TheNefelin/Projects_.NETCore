using ClassLibrary.Common.Models;
using ClassLibrary.PortfolioDapper.DTOs;
using ClassLibrary.PortfolioDapper.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/portfolio")]
    [ApiController]
    [ServiceFilter(typeof(ApiKeyFilter))]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet("projects")]
        public async Task<ActionResult<ResponseApi<IEnumerable<DataProjectDTO>>>> GetAllProjects(CancellationToken cancellationToken) 
        {
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