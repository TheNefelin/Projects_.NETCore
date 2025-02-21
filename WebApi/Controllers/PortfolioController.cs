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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PortfolioController(IPortfolioService portfolioService, IWebHostEnvironment webHostEnvironment)
        {
            _portfolioService = portfolioService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("img")]
        public IActionResult GetImg(string fileName)
        {
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "Portfolio");
            var filePath = Path.Combine(path, fileName);

            if (System.IO.File.Exists(filePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);

                return File(b, "image/webp");
            }

            return BadRequest(new { Msge = "El Archivo No Existe" });
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