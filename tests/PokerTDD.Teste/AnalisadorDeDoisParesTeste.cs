using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeDoisParesTeste
    {
        [Theory]
        [InlineData("2S", "2D", "10C", "10H", "3S")]
        [InlineData("AH", "AD", "KC", "QD", "KS")]
        [InlineData("7S", "7D", "KC", "AD", "AC")]
        [InlineData("QD", "QS", "AC", "10H", "AS")]
        [InlineData("QS", "KD", "KC", "QD", "2S")]
        [InlineData("10S", "AS", "10C", "AD", "KC")]
        public void Deve_ser_uma_mao_valida(
            string carta1, string carta2, string carta3, string carta4, string carta5
        )
        {
            var mao = new[] {
                carta1,
                carta2,
                carta3,
                carta4,
                carta5
            };
            
            var ehValida = AnalisadorDeDoisPares.EhUmaMaoValida(mao);

            Assert.True(ehValida);
        }

        [Theory]
        [InlineData("3H", "3D", "10C", "10H", "3S")]
        [InlineData("AH", "AD", "KC", "QD", "6S")]
        [InlineData("QH", "7D", "7C", "QC", "QD")]
        public void Nao_deve_ser_uma_mao_valida(
            string carta1, string carta2, string carta3, string carta4, string carta5
        )
        {
            var mao = new[] {
                carta1,
                carta2,
                carta3,
                carta4,
                carta5
            };
            
            var ehValida = AnalisadorDeDoisPares.EhUmaMaoValida(mao);

            Assert.False(ehValida);
        }
    }
}