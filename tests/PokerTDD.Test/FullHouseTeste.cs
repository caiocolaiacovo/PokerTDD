using System;
using System.Collections.Generic;
using System.Text;
using PokerTDD.Cartas;
using Xunit;

namespace PokerTDD.Test
{
    public class FullHouseTeste
    {
        [Theory]
        [MemberData(nameof(DadosValidos))]
        public void Deve_validar(List<Carta> cartas)
        {
            var valido = FullHouse.Validar(cartas);

            Assert.True(valido);
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

        public class FullHouse
        {
            public static bool Validar(List<Carta> cartas)
            {
                throw new NotImplementedException();
            }
        }
    }
}
