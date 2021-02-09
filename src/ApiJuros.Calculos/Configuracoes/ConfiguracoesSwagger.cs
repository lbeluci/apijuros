using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace ApiJuros.Calculos.Configuracoes
{
    public static class ConfiguracoesSwagger
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            string xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            OpenApiInfo apiInfo = new OpenApiInfo() 
            { 
                Title = "API Cálculos Juros", 
                Version = "1.0", 
                Description = "<b>API 2 - Efetua o cálculo de juros compostos</b>",
                Contact = new OpenApiContact() { Name = "Luiz Henrique Beluci Terra", Url = new Uri("https://www.linkedin.com/in/luiz-henrique-beluci-terra-37366629/") }
            };

            services.AddSwaggerGen(options => {
                options.SwaggerDoc("apicalculosjuros", apiInfo); 
                options.IncludeXmlComments(xmlFilePath);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();
            
            app.UseSwaggerUI(options => { 
                options.SwaggerEndpoint("/swagger/apicalculosjuros/swagger.json", "apicalculosjuros"); 
                options.RoutePrefix = "";
            });

            return app;
        }
    }
}