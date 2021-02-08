using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using System.Globalization;

namespace ApiJuros.Calculos.Configuracoes
{
    public static class ConfiguracoesLocalizacao
    {
        public static IApplicationBuilder UseLocalization(this IApplicationBuilder app, string cultureName)
        {
            var defaultCulture = new CultureInfo(cultureName);

            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            };

            app.UseRequestLocalization(localizationOptions);

            return app;
        }
    }
}