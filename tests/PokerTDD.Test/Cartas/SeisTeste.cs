using ExpectedObjects;
using PokerTDD.Cartas;
using Xunit;

namespace PokerTDD.Test.Cartas
{
    public class SeisTeste
    {
        [Theory]
        [InlineData(Naipe.Ouro)]
        [InlineData(Naipe.Copa)]
        [InlineData(Naipe.Espadas)]
        [InlineData(Naipe.Paus)]
        public void Deve_criar_uma_carta(Naipe naipe)
        {
            var cartaEsperada = new {
                Valor = 6,
                Naipe = naipe
            };

            var carta = new Seis(naipe);
            
            cartaEsperada.ToExpectedObject().ShouldMatch(carta);
        }
    }
}