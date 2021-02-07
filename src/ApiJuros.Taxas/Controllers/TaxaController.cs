using Microsoft.AspNetCore.Mvc;

namespace ApiJuros.Taxas.Controllers
{
    [ApiController]
    public class TaxaController : Controller
    {
        [HttpGet]
        [Route("taxajuros")]
        public string ObterTaxaJuros()
        {
            return "0,01";
        }
    }
}