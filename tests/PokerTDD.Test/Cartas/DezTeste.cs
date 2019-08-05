using ExpectedObjects;
using PokerTDD.Cartas;
using Xunit;

namespace PokerTDD.Test.Cartas
{
    public class DezTeste
    {
        [Theory]
        [InlineData(Naipe.Ouro)]
        [InlineData(Naipe.Copa)]
        [InlineData(Naipe.Espadas)]
        [InlineData(Naipe.Paus)]
        public void Deve_criar_uma_carta(Naipe naipe)
        {
            var cartaEsperada = new {
                Valor = 10,
                Naipe = naipe
            };

            var carta = new Dez(naipe);
            
            cartaEsperada.ToExpectedObject().ShouldMatch(carta);
        }
    }
}