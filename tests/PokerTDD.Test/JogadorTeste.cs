using System;
using ExpectedObjects;
using Xunit;

namespace PokerTDD.Test
{
    public class JogadorTeste
    {
        public JogadorTeste()
        {
        }

        [Fact]
        public void Deve_criar_um_jogador()
        {
            var jogadorEsperado = new {
                Nome = "Jogador 1"
            };

            var jogador = new Jogador("Jogador 1");

            jogadorEsperado.ToExpectedObject().ShouldMatch(jogador);
        }
    }
}
