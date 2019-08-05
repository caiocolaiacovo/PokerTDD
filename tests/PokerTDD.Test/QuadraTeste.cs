using System.Collections.Generic;
using PokerTDD.Cartas;
using Xunit;

namespace PokerTDD.Test
{
    public partial class QuadraTeste
    {
        [Theory]
        [MemberData(nameof(DadosValidos))]
        public void Deve_ser_valido(List<Carta> cartas)
        {
            var valido = Quadra.Validar(cartas);

            Assert.True(valido);
        }

        [Theory]
        [MemberData(nameof(DadosInvalidos))]
        public void Deve_ser_invalido(List<Carta> cartas)
        {
            var valido = Quadra.Validar(cartas);

            Assert.False(valido);
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

        public static IEnumerable<object[]> DadosInvalidos =>
            new List<object[]>
            {
                new object[] {
                    new List<Carta> {
                        new Dois(Naipe.Espadas), new Dois(Naipe.Ouro), new Dois(Naipe.Espadas), new Dois(Naipe.Paus), new Dois(Naipe.Paus)
                    }
                },
                new object[] {
                    new List<Carta> {
                        new Cinco(Naipe.Espadas), new Cinco(Naipe.Ouro), new Dois(Naipe.Espadas), new Dama(Naipe.Paus), new Valete(Naipe.Paus)
                    }
                },
                new object[] {
                    new List<Carta> {
                        new Quatro(Naipe.Espadas), new Cinco(Naipe.Ouro), new Seis(Naipe.Espadas), new Sete(Naipe.Paus), new Oito(Naipe.Paus)
                    }
                },
            };
    }
}
