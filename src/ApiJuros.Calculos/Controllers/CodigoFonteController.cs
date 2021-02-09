using Microsoft.AspNetCore.Mvc;

namespace ApiJuros.Calculos.Controllers
{
    /// <summary>
    /// API 2
    /// </summary>
    [ApiController]
    public class CodigoFonteController : Controller
    {
        /// <summary>
        /// Retorna a url onde se encontra o código fonte das APIs 1 e 2 no GitHub.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("showmethecode")]
        public IActionResult ShowMeTheCode()
        {
            return Ok("https://github.com/lbeluci/apijuros");
        }
    }
}