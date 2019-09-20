using System;
using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeCartaAltaTeste
    {
        public AnalisadorDeCartaAlta _analisador { get; private set; }

        public AnalisadorDeCartaAltaTeste()
        {
            _analisador = new AnalisadorDeCartaAlta();
        }

        [Fact]
        public void Deve_ser_um_analisador_de_mao()
        {
            Assert.True(_analisador is IAnalisadorDeMao);
            Assert.True(_analisador is AnalisadorDeMaoBase);
        }

        [Fact]
        public void Deve_possuir_a_ordem_10()
        {
            const int ordemEsperada = 10;

            var ordem = _analisador.Ordem;

            Assert.Equal(ordemEsperada, ordem);
        }

        [Fact]
        public void Deve_ser_uma_mao_valida_()
        {
            Assert.True(_analisador.EhValida(new string[]{ "AS", "2D", "3H", "KC", "7S" }));
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