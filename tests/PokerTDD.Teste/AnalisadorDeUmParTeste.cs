using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeUmParTeste
    {
        [Theory]
        [InlineData("QS", "2D", "QC", "10H", "3S")]
        [InlineData("AH", "AD", "KC", "QD", "JS")]
        [InlineData("4D", "KD", "QC", "2H", "2S")]
        [InlineData("6H", "AD", "KC", "QD", "QS")]
        [InlineData("7S", "3D", "8C", "KD", "KC")]
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
            
            var ehValida = AnalisadorDeUmPar.EhUmaMaoValida(mao);

            Assert.True(ehValida);
        }

        [Theory]
        [InlineData("2S", "2D", "10C", "10H", "AS")]
        [InlineData("KH", "AD", "KC", "KD", "KS")]
        [InlineData("4D", "10D", "KC", "JH", "QS")]
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
            
            var ehValida = AnalisadorDeUmPar.EhUmaMaoValida(mao);

            Assert.False(ehValida);
        }
    }
}