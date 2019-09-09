using System.Collections.Generic;
using ExpectedObjects;
using Moq;
using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeStraightFlushTeste
    {
        private Mock<IAnalisadorDeMao> _analisadorDeStraight { get; private set; }
        public Mock<IAnalisadorDeMao> _analisadorDeFlush { get; private set; }
        public AnalisadorDeStraightFlush _analisador { get; private set; }

        public AnalisadorDeStraightFlushTeste()
        {
            _analisadorDeFlush = new Mock<IAnalisadorDeMao>();
            _analisadorDeStraight = new Mock<IAnalisadorDeMao>();

            _analisador = new AnalisadorDeStraightFlush(_analisadorDeFlush.Object, _analisadorDeStraight.Object);
        }

        [Fact]
        public void Deve_criar_com_um_analisador_de_flush()
        {
            var analisadorEsperado = new
            {
                AnalisadorDeFlush = _analisadorDeFlush.Object
            };

            analisadorEsperado.ToExpectedObject().ShouldMatch(_analisador);
        }

        [Fact]
        public void Deve_invocar_o_analisador_de_flush_ao_validar_mao()
        {
            var mao = new [] { "2C", "KS", "10C", "AD", "JH" };
            _analisadorDeFlush.Setup(a => a.EhValida(mao)).Returns(true);

            _analisador.EhValida(mao);

            _analisadorDeFlush.Verify(a => a.EhValida(mao));
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
            _analisadorDeFlush.Setup(a => a.EhValida(It.IsAny<IEnumerable<string>>())).Returns(true);

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