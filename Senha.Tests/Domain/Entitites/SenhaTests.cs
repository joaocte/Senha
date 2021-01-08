using Xunit;

namespace Senha.Tests.Domain.Entitites
{
    public class SenhaTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("aa")]
        [InlineData("ab")]
        [InlineData("AAAbbbCc")]
        [InlineData("AbTp9!foo")]
        [InlineData("AbTp9!foA")]
        [InlineData("AbTp9 fok")]
        public void DeveInstanciarUmaNovaSenhaInvalida(string senha)
        {
            var senhaDomain = new Senha.Domain.Entities.Senha(senha);

            Assert.NotNull(senhaDomain);
            Assert.False(senhaDomain.IsValid());
        }

        [Theory]
        [InlineData("AbTp9!fok")]
        public void DeveInstanciarUmaNovaSenhaValida(string senha)
        {
            var senhaDomain = new Senha.Domain.Entities.Senha(senha);

            Assert.NotNull(senhaDomain);
            Assert.True(senhaDomain.IsValid());
        }
        [Theory]
        [InlineData("")]
        [InlineData("aa")]
        [InlineData("ab")]
        [InlineData("AAAbbbCc")]
        [InlineData("AbTp9!foo")]
        [InlineData("AbTp9!foA")]
        [InlineData("AbTp9 fok")]
        [InlineData("AbTp9!fok")]
        public void DeveConverterUmaSenhaEmString(string senha)
        {
            var senhaDomain = new Senha.Domain.Entities.Senha(senha);
            string senhaString = senhaDomain;
            Assert.IsType<string>(senhaString);
        }
    }
}
