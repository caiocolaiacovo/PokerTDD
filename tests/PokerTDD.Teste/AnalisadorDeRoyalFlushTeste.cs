using System;
using System.Collections.Generic;
using ExpectedObjects;
using Moq;
using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeRoyalFlushTeste
    {
        public Mock<IAnalisadorDeMao> _analisadorDeFlush;

        public AnalisadorDeRoyalFlush _analisador;

        public AnalisadorDeRoyalFlushTeste()
        {
            _analisadorDeFlush = new Mock<IAnalisadorDeMao>();

            _analisador = new AnalisadorDeRoyalFlush(_analisadorDeFlush.Object);
        }

        [Fact]
        public void Deve_ser_um_analisador_de_mao()
        {
            Assert.True(_analisador is IAnalisadorDeMao);
            Assert.True(_analisador is AnalisadorDeMaoBase);
        }

        [Fact]
        public void Deve_criar_com_um_analisador_de_flush()
        {
            var analisadorEsperado = new {
                AnalisadorDeFlush = _analisadorDeFlush.Object
            };

            analisadorEsperado.ToExpectedObject().ShouldMatch(_analisador);
        }

        [Fact]
        public void Deve_invocar_o_analisador_de_flush_ao_validar_mao()
        {
            var mao = new string[] { "10S", "QH", "3C", "4D", "10H" };
            _analisadorDeFlush.Setup(a => a.EhValida(mao)).Returns(true);

            _analisador.EhValida(mao);

            _analisadorDeFlush.Verify(a => a.EhValida(mao));
        }

        [Theory]
        [InlineData("10H", "JH", "QH", "KH", "AH")]
        [InlineData("AS", "10S", "JS", "QS", "KS")]
        [InlineData("KD", "AD", "10D", "JD", "QD")]
        [InlineData("QC", "KC", "AC", "10C", "JC")]
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
        [InlineData("10S", "JH", "QH", "KH", "AH", false)]
        [InlineData("AS", "9S", "JS", "QS", "KS", true)]
        [InlineData("KD", "AH", "10S", "JC", "QD", false)]
        [InlineData("2C", "4C", "KC", "10C", "KC", true)]
        public void Nao_deve_ser_uma_mao_valida(
            string carta1, string carta2, string carta3, string carta4, string carta5, bool flushValido)
        {
            var mao = new[] {
                carta1,
                carta2,
                carta3,
                carta4,
                carta5
            };
            _analisadorDeFlush.Setup(a => a.EhValida(It.IsAny<IEnumerable<string>>())).Returns(flushValido);
            
            var ehValida = _analisador.EhValida(mao);

            Assert.False(ehValida);
        }

        [Fact]
        public void Nao_deve_ser_uma_mao_valida_caso_seja_informada_uma_mao_vazia()
        {
            const string mensagemDeErroEsperada = "É obrigatório informar uma mão para validar";

            void Acao() => _analisador.EhValida(new string[]{});

            var mensagemDeErro = Assert.Throws<ArgumentException>(Acao).Message;
            Assert.Equal(mensagemDeErroEsperada, mensagemDeErro);
        }

        [Fact]
        public void Nao_deve_ser_uma_mao_valida_caso_seja_informada_uma_mao_nula()
        {
            const string mensagemDeErroEsperada = "É obrigatório informar uma mão para validar";

            void Acao() => _analisador.EhValida(null);

            var mensagemDeErro = Assert.Throws<ArgumentException>(Acao).Message;
            Assert.Equal(mensagemDeErroEsperada, mensagemDeErro);
        }

        [Fact]
        public void Deve_possuir_a_ordem_1()
        {
            const int ordemEsperada = 1;

            var ordem = _analisador.Ordem;

            Assert.Equal(ordemEsperada, ordem);
        }
    }
}