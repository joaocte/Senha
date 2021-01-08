using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace Senha.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Validador de Senha",
                    Description = "Projeto inicial para Validação de Senha",
                    Contact = new OpenApiContact { Name = "João Rêgo", Email = "joaocte@gmail.com" }
                });
                s.DocumentFilter<ReplaceVersionWithExactValueInPath>();
                s.OperationFilter<RemoveVersionFromParameter>();
            });
            services.AddApiVersioning(config =>
            {
                // Definindo a versão padrão da API
                config.DefaultApiVersion = new ApiVersion(1, 0);

                // Quando não for informado a versão da API, assumir a padrão
                config.AssumeDefaultVersionWhenUnspecified = true;
                // Mostrando a API suportada para o endpoint consultado
                config.ReportApiVersions = true;
                // Configura como a versão da API será passada pelo cliente.
                config.ApiVersionReader = new UrlSegmentApiVersionReader();
            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
    public class RemoveVersionFromParameter : IOperationFilter
    {
        /// <inheritdoc/>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var versionParameter = operation.Parameters.Single(p => p.Name == "version");
            operation.Parameters.Remove(versionParameter);
        }
    }

    public class ReplaceVersionWithExactValueInPath : IDocumentFilter
    {
        /// <inheritdoc/>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var oap = new OpenApiPaths();
            foreach (var p in swaggerDoc.Paths)
                oap.Add(p.Key.Replace("v{version}", swaggerDoc.Info.Version),
                    p.Value);
            swaggerDoc.Paths = oap;
        }
    }
}
