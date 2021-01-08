using Microsoft.AspNetCore.Mvc;
using Senha.Application.Inputs;
using Senha.Application.UseCases.ValidarSenhaUseCase;
using System.Threading.Tasks;

namespace Senha.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SenhaController : ControllerBase
    {



        [HttpGet]
        [Route("{senha}/validar")]
        public async Task<bool> ValidarSenha([FromRoute] string senha, [FromServices] IValidarSenhaUseCase validarSenhaUseCase)
        {
            var input = new ValidarSenhaInput { Senha = senha };
            var senhaValida = await validarSenhaUseCase.ExecuteAsync(input);

            return senhaValida.SenhaValida;
        }
    }
}
