using Senha.Application.Inputs;
using Senha.Application.UseCases.ValidarSenhaUseCase;
using Xunit;

namespace Senha.Tests.Application
{
    public class ValidarSenhaUseCaseTests
    {
        private ValidarSenhaUseCase validarSenhaUseCase;

        public ValidarSenhaUseCaseTests()
        {
            validarSenhaUseCase = new ValidarSenhaUseCase();

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

            Assert.False(validarSenhaUseCase.ExecuteAsync(input).Result.SenhaValida);
        }

        [Theory]
        [InlineData("AbTp9!fok")]
        public void AoRealizarValidacaoDeSenhasValidas_ReturnTrue(string senha)
        {
            ValidarSenhaInput input = new ValidarSenhaInput { Senha = senha };
            Assert.True(validarSenhaUseCase.ExecuteAsync(input).Result.SenhaValida);
        }
    }
}
