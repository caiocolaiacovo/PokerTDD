using System.Collections.Generic;
using ExpectedObjects;
using PokerTDD.Cartas;
using PokerTDD.Maos;
using Xunit;

namespace PokerTDD.Test.Maos
{
    public class StraightFlushTeste
    {
        public static Naipe _naipe = Naipe.Espadas;

        [Fact]
        public void Deve_criar_uma_mao()
        {
            var maoEsperada = new {
                Cartas = new List<Carta>(),
                Valor = (int)ValorDaMao.StraightFlush
            };

            var mao = new StraightFlush(new List<Carta>());

            maoEsperada.ToExpectedObject().ShouldMatch(mao);
        }

        [Theory]
        [MemberData(nameof(DadosValidos))]
        public void Deve_ser_valido(List<Carta> cartas)
        {
            var valido = StraightFlush.Validar(cartas);

            Assert.True(valido);
        }

        [Theory]
        [MemberData(nameof(DadosInvalidos))]
        public void Deve_ser_invalido(List<Carta> cartas)
        {
            var valido = StraightFlush.Validar(cartas);

            Assert.False(valido);
        }

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

        public static IEnumerable<object[]> DadosInvalidos =>
            new List<object[]>
            {
                new object[] {
                    new List<Carta> {
                        new Cinco(Naipe.Copa), new Seis(_naipe), new Dois(_naipe), new Quatro(_naipe), new Tres(_naipe)
                    }
                },
                new object[] {
                    new List<Carta> {
                        new Sete(_naipe), new Nove(Naipe.Copa), new Dez(_naipe), new Seis(_naipe), new Oito(_naipe)
                    }
                },
                new object[] {
                    new List<Carta> {
                        new Oito(_naipe), new Nove(_naipe), new Dama(_naipe), new Valete(_naipe), new Rei(_naipe)
                    }
                },
            };
    }
}