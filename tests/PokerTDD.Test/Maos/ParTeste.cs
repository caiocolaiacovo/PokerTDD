using System;
using System.Collections.Generic;
using System.Text;
using ExpectedObjects;
using PokerTDD.Cartas;
using PokerTDD.Maos;
using Xunit;

namespace PokerTDD.Test.Maos
{
    public class ParTeste
    {
        [Fact]
        public void Deve_criar_uma_mao()
        {
            var maoEsperada = new
            {
                Cartas = new List<Carta>(),
                Valor = (int)ValorDaMao.Par
            };

            var mao = new Par(new List<Carta>());

            maoEsperada.ToExpectedObject().ShouldMatch(mao);
        }

        public class Par : Mao
        {
            public Par(List<Carta> cartas) : base((int)ValorDaMao.Par, cartas) { }
        }
    }
}
