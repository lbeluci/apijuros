using Microsoft.AspNetCore.Mvc;

namespace ApiJuros.Calculos.Controllers
{
    [ApiController]
    public class CodigoFonteController : Controller
    {
        [HttpGet]
        [Route("showmethecode")]
        public string ShowMeTheCode()
        {
            return "https://github.com/lbeluci/apijuros";
        }
    }
}
