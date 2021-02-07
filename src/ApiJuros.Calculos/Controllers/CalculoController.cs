using ApiJuros.Calculos.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace ApiJuros.Calculos.Controllers
{
    [ApiController]
    public class CalculoController : Controller
    {
        private readonly ICalcularJurosCompostosServico _calcularJurosCompostosServico;

        public CalculoController(ICalcularJurosCompostosServico calcularJurosCompostosServico)
        {
            _calcularJurosCompostosServico = calcularJurosCompostosServico;
        }

        [HttpGet]
        [Route("calculajuros")]
        public string CalcularJuros([FromQuery] decimal valorInicial, [FromQuery] int meses)
        {
            return _calcularJurosCompostosServico.CalcularTruncandoEmDuasCasasDecimais(valorInicial, 0.01M, meses).ToString("N2", CultureInfo.CreateSpecificCulture("pt-BR"));
        }
    }
}