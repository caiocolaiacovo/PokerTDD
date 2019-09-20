using System;
using System.Collections.Generic;
using ExpectedObjects;
using Moq;
using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeStraightFlushTeste
    {
        public Mock<IAnalisadorDeMao> _analisadorDeStraight;
        public Mock<IAnalisadorDeMao> _analisadorDeFlush;
        public AnalisadorDeStraightFlush _analisador;

        public AnalisadorDeStraightFlushTeste()
        {
            _analisadorDeFlush = new Mock<IAnalisadorDeMao>();
            _analisadorDeStraight = new Mock<IAnalisadorDeMao>();

            _analisador = new AnalisadorDeStraightFlush(_analisadorDeFlush.Object, _analisadorDeStraight.Object);
        }

        [Fact]
        public void Deve_ser_um_analisador_de_mao()
        {
            Assert.True(_analisador is IAnalisadorDeMao);
            Assert.True(_analisador is AnalisadorDeMaoBase);
        }

        [Fact]
        public void Deve_criar_com_analisador_de_flush_e_straight()
        {
            var analisadorEsperado = new
            {
                AnalisadorDeFlush = _analisadorDeFlush.Object,
                AnalisadorDeStraight = _analisadorDeStraight.Object
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

        [Fact]
        public void Deve_invocar_o_analisador_de_straight_ao_validar_mao()
        {
            var mao = new [] { "2C", "KS", "10C", "AD", "JH" };
            _analisadorDeFlush.Setup(a => a.EhValida(It.IsAny<IEnumerable<string>>())).Returns(true);
            _analisadorDeStraight.Setup(a => a.EhValida(mao)).Returns(true);

            _analisador.EhValida(mao);

            _analisadorDeStraight.Verify(a => a.EhValida(mao));
        }

        [Fact]
        public void Deve_ser_invalida_caso_o_analisador_de_flush_falhe()
        {
            var mao = new [] { "2C", "KS", "10C", "AD", "JH" };
            _analisadorDeFlush.Setup(a => a.EhValida(It.IsAny<IEnumerable<string>>())).Returns(false);
            _analisadorDeStraight.Setup(a => a.EhValida(It.IsAny<IEnumerable<string>>())).Returns(true);

            var ehValida = _analisador.EhValida(mao);

            Assert.False(ehValida);
        }

        [Fact]
        public void Nao_deve_invocar_o_analisador_de_straight_caso_o_analisador_de_flush_falhe()
        {
            var mao = new [] { "2C", "KS", "10C", "AD", "JH" };
            _analisadorDeFlush.Setup(a => a.EhValida(It.IsAny<IEnumerable<string>>())).Returns(false);
            _analisadorDeStraight.Setup(a => a.EhValida(It.IsAny<IEnumerable<string>>())).Returns(true);

            _analisador.EhValida(mao);

            _analisadorDeStraight.Verify(a => a.EhValida(It.IsAny<IEnumerable<string>>()), Times.Never);
        }

        [Fact]
        public void Deve_possuir_a_ordem_2()
        {
            const int ordemEsperada = 2;

            var ordem = _analisador.Ordem;

            Assert.Equal(ordemEsperada, ordem);
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
    }
}