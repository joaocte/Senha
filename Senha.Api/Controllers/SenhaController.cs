using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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


        private readonly ILogger<SenhaController> _logger;

        public SenhaController(ILogger<SenhaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{senha}/validar")]
        public Task<bool> ValidarSenha([FromRoute] string senha, [FromServices] IValidarSenhaUseCase validarSenhaUseCase)
        {
            var input = new ValidarSenhaInput { Senha = senha };
            return validarSenhaUseCase.ExecuteAsync(input);
        }
    }
}
