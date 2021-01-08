using Senha.Application.Inputs;
using Senha.Application.Output;
using System.Threading.Tasks;

namespace Senha.Application.UseCases.ValidarSenhaUseCase
{
    public class ValidarSenhaUseCase : IValidarSenhaUseCase
    {
        public void Dispose()
        {
            //TODO: Implementar quando estiver algo mais complexo.
        }

        public async Task<ValidarSenhaOutput> ExecuteAsync(ValidarSenhaInput input)
        {
            return new ValidarSenhaOutput { SenhaValida = input.Senha.IsValid() };
        }
    }
}
