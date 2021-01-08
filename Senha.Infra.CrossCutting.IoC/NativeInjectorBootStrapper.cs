using Microsoft.Extensions.DependencyInjection;
using Senha.Application.UseCases.ValidarSenhaUseCase;

namespace Senha.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IValidarSenhaUseCase, ValidarSenhaUseCase>();
        }
    }
}
