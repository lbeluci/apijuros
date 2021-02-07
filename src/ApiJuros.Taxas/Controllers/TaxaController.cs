using Microsoft.AspNetCore.Mvc;

namespace ApiJuros.Taxas.Controllers
{
    [ApiController]
    public class TaxaController : Controller
    {
        [HttpGet]
        [Route("taxajuros")]
        public IActionResult ObterTaxaJuros()
        {
            return Ok("0,01");
        }
    }
}