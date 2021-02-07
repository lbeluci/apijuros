using Microsoft.AspNetCore.Mvc;

namespace ApiJuros.Calculos.Controllers
{
    [ApiController]
    public class CodigoFonteController : Controller
    {
        [HttpGet]
        [Route("showmethecode")]
        public IActionResult ShowMeTheCode()
        {
            return Ok("https://github.com/lbeluci/apijuros");
        }
    }
}