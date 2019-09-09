using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeStraightFlushTeste
    {
        public AnalisadorDeStraightFlush _analisador { get; private set; }

        public AnalisadorDeStraightFlushTeste()
        {
            _analisador = new AnalisadorDeStraightFlush();
        }

        [Theory]
        [InlineData("5H", "2H", "6H", "3H", "4H")]
        [InlineData("KD", "9D", "JD", "10D", "QD")]
        [InlineData("5C", "6C", "7C", "8C", "9C")]
        [InlineData("2S", "5S", "6S", "3S", "4S")]
        public void Deve_ser_uma_mao_valida(
            string carta1, string carta2, string carta3, string carta4, string carta5)
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
        [InlineData("2C", "3S", "8S", "8D", "QD")]
        [InlineData("2C", "3S", "4S", "5D", "6D")]
        [InlineData("5H", "2D", "6H", "3S", "4C")]
        public void Nao_deve_ser_uma_mao_valida(
            string carta1, string carta2, string carta3, string carta4, string carta5)
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
        public void Deve_possuir_a_ordem_2()
        {
            const int ordemEsperada = 2;

            var ordem = _analisador.Ordem;

            Assert.Equal(ordemEsperada, ordem);
        }
    }
}