using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Connections;

namespace WebApi.Controllers
{
    [Route("api/guia-juegos")]
    [ApiController]
    public class GuiaJuegosController : ControllerBase
    {
        public readonly GuiaJuegosDbContext _context;

        public GuiaJuegosController(GuiaJuegosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> Get() {
            var result = await _context.GJ_Juegos.ToListAsync();

            return result;
        }
    }
}
