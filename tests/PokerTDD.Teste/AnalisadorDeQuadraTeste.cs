using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeQuadraTeste
    {
        public AnalisadorDeQuadra _analisador { get; private set; }

        public AnalisadorDeQuadraTeste()
        {
            _analisador = new AnalisadorDeQuadra();
        }

        [Theory]
        [InlineData("2D", "2H", "2C", "2S", "5D")]
        [InlineData("QD", "QH", "QC", "QS", "AD")]
        [InlineData("10D", "10H", "10C", "2S", "10S")]
        [InlineData("2D", "6H", "6C", "6S", "6D")]
        [InlineData("JD", "JH", "JC", "JS", "5D")]
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

            var ehValida = _analisador.EhValida(mao);

            Assert.True(ehValida);
        }

        [Theory]
        [InlineData("3D", "2H", "2C", "2S", "5D")]
        [InlineData("KD", "QH", "QC", "QS", "AD")]
        [InlineData("KD", "AH", "10C", "2S", "QS")]
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

            var ehValida = _analisador.EhValida(mao);

            Assert.False(ehValida);
        }

        [Fact]
        public void Deve_possuir_a_ordem_3()
        {
            const int ordemEsperada = 3;

            var ordem = _analisador.Ordem;

            Assert.Equal(ordemEsperada, ordem);
        }

        [Theory]
        [InlineData("2D", "2H", "2C", "2S", "5D", 2)]
        [InlineData("QD", "QH", "QC", "QS", "AD", 12)]
        [InlineData("10D", "10H", "10C", "2S", "10S", 10)]
        public void Deve_obter_a_carta_mais_alta_da_mao(
            string carta1, string carta2, string carta3, string carta4, string carta5, int cartaEsperada
        )
        {
            var mao = new[] { 
                carta1, 
                carta2, 
                carta3, 
                carta4, 
                carta5
            };

            var carta = _analisador.ObterMaiorCartaDaMao(mao);

            Assert.Equal(cartaEsperada, carta);
        }
    }
}