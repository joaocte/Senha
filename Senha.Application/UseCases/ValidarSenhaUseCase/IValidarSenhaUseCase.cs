using Senha.Application.Inputs;
using Senha.Application.Output;
using System;
using System.Threading.Tasks;

namespace Senha.Application.UseCases.ValidarSenhaUseCase
{
    public interface IValidarSenhaUseCase : IDisposable
    {
        Task<ValidarSenhaOutput> ExecuteAsync(ValidarSenhaInput input);
    }
}
