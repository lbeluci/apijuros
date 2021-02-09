using Microsoft.AspNetCore.Mvc;

namespace ApiJuros.Taxas.Controllers
{
    /// <summary>
    /// API 1
    /// </summary>
    [ApiController]
    public class TaxaController : Controller
    {
        /// <summary>
        /// Retorna uma taxa de juros para ser utilizada no cálculo de juros compostos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("taxajuros")]
        public IActionResult ObterTaxaJuros()
        {
            return Ok("0,01");
        }
    }
}