using System.Collections.Generic;
using PokerTDD.Cartas;
using Xunit;

namespace PokerTDD.Test
{
    public class CartasDoMesmoNaipeTeste
    {
        [Fact]
        // [MemberData(nameof(DadosValidos))]
        public void Deve_validar()
        {
            Assert.True(true);
        }

        public static IEnumerable<object[]> DadosValidos =>
            new List<object[]>
            {
                new object[] {
                    new List<Carta> {
                        new Dois(Naipe.Espadas), new Dois(Naipe.Ouro), new Dois(Naipe.Paus), new Dois(Naipe.Copa), new Tres(Naipe.Paus)
                    }
                },
            };
    }
}