using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/img")]
    [ApiController]
    public class ImgController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImgController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [Route("game-guide")]
        public IActionResult GetGuideGameImg(string fileName)
        {
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "GamesGuide");
            var filePath = Path.Combine(path, fileName);

            if (System.IO.File.Exists(filePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);

                return File(b, "image/webp");
            }

            return BadRequest(new { Msge = "El Archivo No Existe" });
        }

        [HttpGet]
        [Route("f1")]
        [ServiceFilter(typeof(ApiKeyFilter))]
        public IActionResult GetF1Img(string fileName)
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

        [HttpGet]
        [Route("portfolio")]
        public IActionResult GetPortfolioImg(string fileName)
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
    }
}
