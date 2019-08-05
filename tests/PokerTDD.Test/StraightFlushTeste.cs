using System;
using System.Collections.Generic;
using System.Linq;
using PokerTDD.Cartas;
using Xunit;

namespace PokerTDD.Test
{
    public class StraightFlushTeste
    {
        public static Naipe _naipe = Naipe.Espadas;

        [Theory]
        [MemberData(nameof(DadosValidos))]
        public void Deve_ser_valido(List<Carta> cartas)
        {
            var valido = StraightFlush.Validar(cartas);

            Assert.True(valido);
        }

        // [Theory]
        // [MemberData(nameof(DadosInvalidos))]
        // public void Deve_ser_invalido()
        // {
        //     var valido = StraightFlush.Validar(cartas);

        //     Assert.False(valido);
        // }

        public static IEnumerable<object[]> DadosValidos =>
        new List<object[]>
        {
            new object[] { 
                new List<Carta> {
                    new Cinco(_naipe), new Seis(_naipe), new Dois(_naipe), new Quatro(_naipe), new Tres(_naipe) 
                }
            },
            new object[] { 
                new List<Carta> {
                    new Sete(_naipe), new Nove(_naipe), new Dez(_naipe), new Seis(_naipe), new Oito(_naipe) 
                }
            },
            new object[] { 
                new List<Carta> {
                    new Rei(_naipe), new Nove(_naipe), new Dama(_naipe), new Valete(_naipe), new Dez(_naipe) 
                }
            },
        };

        // public static IEnumerable<object[]> DadosInvalidos =>
        // new List<object[]>
        // {
        //     new object[] { 
        //         new List<Carta> {
        //             new (Naipe.), new (Naipe.), new (Naipe.), new (Naipe.), new (Naipe.) 
        //         }
        //     },
        // };

        public class StraightFlush
        {
            public static bool Validar(List<Carta> cartas)
            {
                var numeroDeNaipes = cartas.Select(c => c.Naipe).Distinct().Count();

                if (numeroDeNaipes > 1)
                    return false;

                var cartasOrdenadas = cartas.OrderBy(c => c.Valor).ToList();
                var valorDaPrimeiraCarta = cartasOrdenadas.Select(c => c.Valor).First() - 1;
                var cartasEstaoEmSequencia = true;

                cartasOrdenadas.ForEach(c => {
                    valorDaPrimeiraCarta++;

                    if (c.Valor != valorDaPrimeiraCarta)
                        cartasEstaoEmSequencia = false;
                });

                return cartasEstaoEmSequencia;
            }
        }
    }
}