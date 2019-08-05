using ExpectedObjects;
using PokerTDD.Cartas;
using Xunit;

namespace PokerTDD.Test.Cartas
{
    public class DoisTeste
    {
        [Theory]
        [InlineData(Naipe.Ouro)]
        [InlineData(Naipe.Copa)]
        [InlineData(Naipe.Espadas)]
        [InlineData(Naipe.Paus)]
        public void Deve_criar_uma_carta(Naipe naipe)
        {
            var cartaEsperada = new {
                Valor = 2,
                Naipe = naipe
            };

            var carta = new Dois(naipe);
            
            cartaEsperada.ToExpectedObject().ShouldMatch(carta);
        }
    }
}