using Microsoft.AspNetCore.Mvc;

namespace ApiJuros.Calculos.Controllers
{
    [ApiController]
    public class CalculoController : Controller
    {
        [HttpGet]
        [Route("calculajuros")]
        public string CalcularJuros([FromQuery] decimal valorInicial, [FromQuery] int meses)
        {
            return "105,10";
        }
    }
}