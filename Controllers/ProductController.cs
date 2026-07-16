using Microsoft.AspNetCore.Mvc;
using StockControlApi.Data;

namespace StockControlApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : Controller
    {
        private ApiStockControlContext _context;

        public ProductController(ApiStockControlContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
