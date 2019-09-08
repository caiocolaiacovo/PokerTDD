using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeTrincaTeste
    {
        [Theory]
        [InlineData("3S", "2D", "3C", "7H", "3S")]
        [InlineData("KH", "KD", "3C", "7H", "KS")]
        [InlineData("AS", "2D", "3C", "AD", "AC")]
        [InlineData("10S", "10D", "10C", "7H", "3S")]
        [InlineData("AH", "AD", "AC", "QD", "JS")]
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
            
            var ehValida = AnalisadorDeTrinca.EhUmaMaoValida(mao);

            Assert.True(ehValida);
        }

        [Theory]
        [InlineData("3S", "2D", "3C", "2H", "3S")]
        [InlineData("KH", "KD", "3C", "3H", "KS")]
        [InlineData("AS", "2D", "AC", "AD", "AC")]
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
            
            var ehValida = AnalisadorDeTrinca.EhUmaMaoValida(mao);

            Assert.False(ehValida);
        }
    }
}