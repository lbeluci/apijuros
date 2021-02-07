using ApiJuros.Calculos.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace ApiJuros.Calculos.Controllers
{
    [ApiController]
    public class CalculoController : Controller
    {
        private readonly IServicoCalcularJurosCompostos _servicoCalcularJurosCompostos;
        private readonly INotificador _notificador;

        public CalculoController(IServicoCalcularJurosCompostos servicoCalcularJurosCompostos, INotificador notificador)
        {
            _servicoCalcularJurosCompostos = servicoCalcularJurosCompostos;
            _notificador = notificador;
        }
        
        [HttpGet]
        [Route("calculajuros")]
        public IActionResult CalcularJuros([FromQuery] decimal valorInicial, [FromQuery] int meses)
        {
            decimal valorCalculado = _servicoCalcularJurosCompostos.CalcularTruncandoEmDuasCasasDecimais(valorInicial, meses);

            if (_notificador.TemNotificacoes())
            {
                return BadRequest(_notificador.ObterNotificacoes());
            }

            return Ok(valorCalculado.ToString("N2", CultureInfo.CreateSpecificCulture("pt-BR")));
        }
    }
}