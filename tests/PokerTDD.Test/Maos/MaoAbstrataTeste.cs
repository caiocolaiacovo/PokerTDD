using System;
using System.Collections.Generic;
using ExpectedObjects;
using PokerTDD.Cartas;
using PokerTDD.Maos;
using Xunit;

namespace PokerTDD.Test.Maos
{
    public class MaoAbstrataTeste
    {
        public class MaoAbstrata : Mao
        {
            public MaoAbstrata(int valor, List<Carta> cartas) : base(valor, cartas) { }
        }

        [Fact]
        public void Deve_criar_uma_mao()
        {
            const int valor = 9;
            var cartas = new List<Carta>
            {
                new Dois(Naipe.Ouro),
                new Tres(Naipe.Ouro),
                new Quatro(Naipe.Ouro),
                new Cinco(Naipe.Ouro),
                new Seis(Naipe.Ouro)
            };
            var maoEsperada = new
            {
                Valor = valor,
                Cartas = cartas
            };

            var mao = new MaoAbstrata(valor, cartas);

            maoEsperada.ToExpectedObject().ShouldMatch(mao);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Deve_falhar_ao_criar_uma_mao_com_valor_invalido(int valor)
        {
            const string mensagemDeErroEsperada = "É obrigatório informar o Valor";

            void Acao() => new MaoAbstrata(valor, null);

            var mensagemDeErro = Assert.Throws<Exception>((Action) Acao).Message;
            Assert.Equal(mensagemDeErroEsperada, mensagemDeErro);
        }

        [Fact]
        public void Deve_falhar_ao_criar_uma_mao_com_uma_lista_de_cartas_vazia()
        {
            const string mensagemDeErroEsperada = "É obrigatório informar as Cartas";

            void Acao() => new MaoAbstrata(1, new List<Carta>());

            var mensagemDeErro = Assert.Throws<Exception>((Action) Acao).Message;
            Assert.Equal(mensagemDeErroEsperada, mensagemDeErro);
        }

        [Fact]
        public void Deve_falhar_ao_criar_uma_mao_com_uma_lista_de_cartas_nula()
        {
            const string mensagemDeErroEsperada = "É obrigatório informar as Cartas";

            void Acao() => new MaoAbstrata(1, null);

            var mensagemDeErro = Assert.Throws<Exception>((Action) Acao).Message;
            Assert.Equal(mensagemDeErroEsperada, mensagemDeErro);
        }
    }
}