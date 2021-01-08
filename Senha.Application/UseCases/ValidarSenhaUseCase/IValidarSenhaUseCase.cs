using Senha.Application.Inputs;
using System;
using System.Threading.Tasks;

namespace Senha.Application.UseCases.ValidarSenhaUseCase
{
    public interface IValidarSenhaUseCase : IDisposable
    {
        Task<bool> ExecuteAsync(ValidarSenhaInput input);
    }
}
