using ExpectedObjects;
using PokerTDD.Cartas;
using Xunit;

namespace PokerTDD.Test.Cartas
{
    public class CincoTeste
    {
        [Theory]
        [InlineData(Naipe.Ouro)]
        [InlineData(Naipe.Copa)]
        [InlineData(Naipe.Espadas)]
        [InlineData(Naipe.Paus)]
        public void Deve_criar_uma_carta(Naipe naipe)
        {
            var cartaEsperada = new {
                Valor = 5,
                Naipe = naipe
            };

            var carta = new Cinco(naipe);
            
            cartaEsperada.ToExpectedObject().ShouldMatch(carta);
        }
    }
}