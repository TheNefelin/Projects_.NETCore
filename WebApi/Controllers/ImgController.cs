using Microsoft.AspNetCore.Mvc;

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
        [Route("games-guide")]
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
    }
}
