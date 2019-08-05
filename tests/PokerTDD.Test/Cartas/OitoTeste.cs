using ExpectedObjects;
using PokerTDD.Cartas;
using Xunit;

namespace PokerTDD.Test.Cartas
{
    public class OitoTeste
    {
        [Theory]
        [InlineData(Naipe.Ouro)]
        [InlineData(Naipe.Copa)]
        [InlineData(Naipe.Espadas)]
        [InlineData(Naipe.Paus)]
        public void Deve_criar_uma_carta(Naipe naipe)
        {
            var cartaEsperada = new {
                Valor = 8,
                Naipe = naipe
            };

            var carta = new Oito(naipe);
            
            cartaEsperada.ToExpectedObject().ShouldMatch(carta);
        }
    }
}