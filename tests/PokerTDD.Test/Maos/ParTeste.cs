using System.Collections.Generic;
using ExpectedObjects;
using PokerTDD.Cartas;
using PokerTDD.Maos;
using Xunit;

namespace PokerTDD.Test.Maos
{
    public class ParTeste
    {
        [Fact]
        public void Deve_criar_uma_mao()
        {
            var cartas = new List<Carta>
            {
                new Cinco(Naipe.Copa),
                new As(Naipe.Espadas),
                new Dama(Naipe.Copa),
                new Quatro(Naipe.Ouro),
                new Dama(Naipe.Ouro)
            };
            var maoEsperada = new
            {
                Cartas = cartas,
                Valor = (int)ValorDaMao.Par
            };

            var mao = new Par(cartas);

            maoEsperada.ToExpectedObject().ShouldMatch(mao);
        }

        [Theory]
        [MemberData(nameof(DadosValidos))]
        public void Deve_ser_valido(List<Carta> cartas)
        {
            var valido = Par.Validar(cartas);

            Assert.True(valido);
        }

        [Theory]
        [MemberData(nameof(DadosInvalidos))]
        public void Deve_ser_invalido(List<Carta> cartas)
        {
            var valido = Par.Validar(cartas);

            Assert.False(valido);
        }

        public static IEnumerable<object[]> DadosValidos =>
            new List<object[]>
            {
                new object[] { 
                    new List<Carta> {
                        new Cinco(Naipe.Copa), new As(Naipe.Espadas), new Dama(Naipe.Copa), new Quatro(Naipe.Ouro), new Dama(Naipe.Ouro) 
                    }
                },
                new object[] { 
                    new List<Carta> {
                        new Sete(Naipe.Espadas), new Sete(Naipe.Copa), new Dez(Naipe.Copa), new Seis(Naipe.Paus), new Rei(Naipe.Espadas) 
                    }
                },
                new object[] { 
                    new List<Carta> {
                        new Rei(Naipe.Copa), new Rei(Naipe.Paus), new Dama(Naipe.Paus), new Valete(Naipe.Espadas), new As(Naipe.Copa) 
                    }
                },
            };

        public static IEnumerable<object[]> DadosInvalidos =>
            new List<object[]>
            {
                new object[] { 
                    new List<Carta> {
                        new Sete(Naipe.Copa), new Sete(Naipe.Espadas), new Dama(Naipe.Copa), new Sete(Naipe.Ouro), new As(Naipe.Ouro) 
                    }
                },
                new object[] { 
                    new List<Carta> {
                        new Rei(Naipe.Espadas), new As(Naipe.Copa), new Valete(Naipe.Copa), new Dama(Naipe.Paus), new Quatro(Naipe.Espadas) 
                    }
                },
                new object[] { 
                    new List<Carta> {
                        new Sete(Naipe.Copa), new Sete(Naipe.Paus), new Dama(Naipe.Paus), new Sete(Naipe.Espadas), new As(Naipe.Copa) 
                    }
                },
            };
    }
}
