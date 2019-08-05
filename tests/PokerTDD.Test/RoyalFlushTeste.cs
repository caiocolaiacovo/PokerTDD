using System.Collections.Generic;
using PokerTDD.Cartas;
using Xunit;

namespace PokerTDD.Test
{
    public class RoyalFlushTeste
    {
        public static Naipe _naipe = Naipe.Paus;

        [Fact]
        public void Deve_ser_valido()
        {
            var valido = RoyalFlush.Validar(new List<Carta> { 
                new As(_naipe),
                new Valete(_naipe),
                new Dez(_naipe),
                new Rei(_naipe),
                new Dama(_naipe)
            });

            Assert.True(valido);
        }

        [Theory]
        [MemberData(nameof(Dados))]
        public void Deve_ser_invalido(List<Carta> cartas)
        {
            var valido = RoyalFlush.Validar(cartas);

            Assert.False(valido);
        }

        public static IEnumerable<object[]> Dados =>
        new List<object[]>
        {
            new object[] { 
                new List<Carta> {
                    new As(Naipe.Espadas), new Valete(_naipe), new Dez(_naipe), new Rei(_naipe), new Dama(_naipe) 
                }
            },
            new object[] { 
                new List<Carta> {
                    new As(_naipe), new Valete(Naipe.Espadas), new Dez(_naipe), new Rei(_naipe), new Dama(_naipe) 
                }
            },
            new object[] { 
                new List<Carta> {
                    new As(_naipe), new Valete(_naipe), new Dez(Naipe.Espadas), new Rei(_naipe), new Dama(_naipe) 
                }
            },
            new object[] {
                new List<Carta> {
                    new As(_naipe), new Valete(_naipe), new Dez(_naipe), new Rei(Naipe.Espadas), new Dama(_naipe) 
                }
            },
            new object[] { 
                new List<Carta> {
                    new As(_naipe), new Valete(_naipe), new Dez(_naipe), new Rei(_naipe), new Dama(Naipe.Espadas) 
                }
            }
        };
    }
}