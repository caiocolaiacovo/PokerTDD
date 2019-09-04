using System.Collections.Generic;
using ExpectedObjects;
using Xunit;

namespace PokerTDD.Teste
{
    public class JogadorTeste
    {
        [Fact]
        public void Deve_criar_um_jogador()
        {
            const string nome = "Jogador 1";
            var cartas = new List<string>{ "2C", "AD", "10H", "2D", "KH" };
            var jogadorEsperado = new {
                Nome = nome,
                Cartas = cartas
            };

            var jogador = new Jogador(nome, cartas);

            jogadorEsperado.ToExpectedObject().ShouldMatch(jogador);
        }
    }
}