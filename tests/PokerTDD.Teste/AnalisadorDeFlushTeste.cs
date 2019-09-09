using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeFlushTeste
    {
        public AnalisadorDeFlush _analisador { get; private set; }

        public AnalisadorDeFlushTeste()
        {
            _analisador = new AnalisadorDeFlush();
        }

        [Theory]
        [InlineData("2H", "6H", "AH", "KH", "3H")]
        [InlineData("AC", "7C", "10C", "QC", "JC")]
        [InlineData("10D", "KD", "5D", "JD", "QD")]
        [InlineData("10H", "7H", "2H", "4H", "AH")]
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
        [InlineData("2S", "6H", "AH", "KD", "3H")]
        [InlineData("AC", "7H", "10C", "QC", "JC")]
        [InlineData("10D", "KD", "5D", "JD", "QS")]
        [InlineData("10C", "7C", "2H", "4H", "AD")]
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
        public void Deve_possuir_a_ordem_5()
        {
            const int ordemEsperada = 5;

            var ordem = _analisador.Ordem;

            Assert.Equal(ordemEsperada, ordem);
        }
    }
}