using Senha.Application.Inputs;
using System.Threading.Tasks;

namespace Senha.Application.UseCases.ValidarSenhaUseCase
{
    public class ValidarSenhaUseCase : IValidarSenhaUseCase
    {
        public void Dispose()
        {
            //TODO: Implementar quando estiver algo mais complexo.
        }

        public async Task<bool> ExecuteAsync(ValidarSenhaInput input)
        {
            return input.Senha.IsValid();
        }
    }
}
