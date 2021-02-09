using ApiJuros.Calculos.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace ApiJuros.Calculos.Controllers
{
    /// <summary>
    /// API 2
    /// </summary>
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

        /// <summary>
        /// Retorna o montante calculado em função do capital, da taxa de juros e do tempo.
        /// </summary>
        /// <param name="valorInicial">Valor inicial da negociação</param>
        /// <param name="meses">Tempo em meses em que o valor inicial ficará aplicado</param>
        /// <returns></returns>
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