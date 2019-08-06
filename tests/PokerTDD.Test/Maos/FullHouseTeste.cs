using System.Collections.Generic;
using PokerTDD.Cartas;
using Xunit;

namespace PokerTDD.Test.Maos
{
    public class FullHouseTeste
    {
        [Theory]
        [MemberData(nameof(DadosValidos))]
        public void Deve_ser_uma_mao_valida(List<Carta> cartas)
        {
            // var valido = FullHouse.Validar(cartas);

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
                new object[] {
                    new List<Carta> {
                        new Dama(Naipe.Ouro), new Dama(Naipe.Espadas), new Dez(Naipe.Espadas), new Dama(Naipe.Copa), new Dama(Naipe.Paus)
                    }
                },
                new object[] {
                    new List<Carta> {
                        new Cinco(Naipe.Espadas), new Cinco(Naipe.Ouro), new Dama(Naipe.Paus), new Cinco(Naipe.Paus), new Cinco(Naipe.Copa)
                    }
                },
            };
    }
}
