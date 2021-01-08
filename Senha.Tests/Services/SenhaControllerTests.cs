using NSubstitute;
using Senha.Api.Controllers;
using Senha.Application.Inputs;
using Senha.Application.Output;
using Senha.Application.UseCases.ValidarSenhaUseCase;
using Xunit;

namespace Senha.Tests.Services
{
    public class SenhaControllerTests
    {

        private SenhaController controller;

        private IValidarSenhaUseCase validarSenhaUseCase;

        public SenhaControllerTests()
        {
            validarSenhaUseCase = Substitute.For<IValidarSenhaUseCase>();

            controller = new SenhaController();
        }

        [Theory]
        [InlineData("")]
        [InlineData("aa")]
        [InlineData("ab")]
        [InlineData("AAAbbbCc")]
        [InlineData("AbTp9!foo")]
        [InlineData("AbTp9!foA")]
        [InlineData("AbTp9 fok")]
        public void AoRealizarValidacaoDeSenhasInvalidas_ReturnFalse(string senha)
        {
            ValidarSenhaInput input = new ValidarSenhaInput { Senha = senha };
            validarSenhaUseCase.ExecuteAsync(Arg.Any<ValidarSenhaInput>()).Returns(new ValidarSenhaOutput { SenhaValida = false });

            Assert.False(controller.ValidarSenha(senha, validarSenhaUseCase).Result);


        }
        [Theory]
        [InlineData("AbTp9!fok")]
        public void AoRealizarValidacaoDeSenhasValidas_ReturnTrue(string senha)
        {
            ValidarSenhaInput input = new ValidarSenhaInput { Senha = senha };
            validarSenhaUseCase.ExecuteAsync(Arg.Any<ValidarSenhaInput>()).Returns(new ValidarSenhaOutput { SenhaValida = true });

            Assert.True(controller.ValidarSenha(senha, validarSenhaUseCase).Result);


        }
    }
}
