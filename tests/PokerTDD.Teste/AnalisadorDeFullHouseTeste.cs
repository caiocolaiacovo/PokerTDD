using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeFullHouseTeste
    {
        public AnalisadorDeFullHouse _analisador { get; private set; }

        public AnalisadorDeFullHouseTeste()
        {
            _analisador = new AnalisadorDeFullHouse();
        }

        [Theory]
        [InlineData("2D", "6H", "6C", "2S", "2H")]
        [InlineData("AH", "AC", "AS", "QC", "QD")]
        [InlineData("10D", "KH", "10C", "10S", "KD")]
        [InlineData("10D", "AH", "10C", "AS", "10H")]
        [InlineData("QH", "QC", "QS", "KC", "KD")]
        [InlineData("2D", "2H", "AC", "AS", "AD")]
        public void Deve_sem_uma_mao_valida(
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
        [InlineData("9H", "AS", "AC", "9D", "9C", 9)]
        [InlineData("8H", "8S", "8C", "AD", "AH", 8)]
        [InlineData("6H", "6S", "KC", "KD", "6D", 6)]
        [InlineData("JH", "6D", "6C", "JD", "JC", 11)]
        public void Deve_obter_a_carta_de_maior_valor(
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

        [Fact]
        public void Deve_possuir_a_ordem_4()
        {
            const int ordemEsperada = 4;

            var ordem = _analisador.Ordem;

            Assert.Equal(ordemEsperada, ordem);
        }
    }
}