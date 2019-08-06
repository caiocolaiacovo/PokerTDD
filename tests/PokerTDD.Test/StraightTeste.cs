using ExpectedObjects;
using PokerTDD.Cartas;
using System.Collections.Generic;
using Xunit;

namespace PokerTDD.Test
{
    public class StraightTeste
    {
        [Fact]
        public void Deve_criar_uma_mao()
        {
            var maoEsperada = new {
                Cartas = new List<Carta>(),
                Valor = (int)ValorDaMao.Straight
            };

            var mao = new Straight(new List<Carta>());

            maoEsperada.ToExpectedObject().ShouldMatch(mao);
        }

        [Theory]
        [MemberData(nameof(DadosValidos))]
        public void Deve_ser_valido(List<Carta> cartas)
        {
            var valido = Straight.Validar(cartas);

            Assert.True(valido);
        }

        [Theory]
        [MemberData(nameof(DadosInvalidos))]
        public void Deve_ser_invalido(List<Carta> cartas)
        {
            var valido = Straight.Validar(cartas);

            Assert.False(valido);
        }

        public static IEnumerable<object[]> DadosValidos =>
            new List<object[]>
            {
                new object[] { 
                    new List<Carta> {
                        new Cinco(Naipe.Copa), new Seis(Naipe.Espadas), new Dois(Naipe.Copa), new Quatro(Naipe.Ouro), new Tres(Naipe.Ouro) 
                    }
                },
                new object[] { 
                    new List<Carta> {
                        new Sete(Naipe.Espadas), new Nove(Naipe.Copa), new Dez(Naipe.Copa), new Seis(Naipe.Paus), new Oito(Naipe.Espadas) 
                    }
                },
                new object[] { 
                    new List<Carta> {
                        new Rei(Naipe.Copa), new Nove(Naipe.Paus), new Dama(Naipe.Paus), new Valete(Naipe.Espadas), new Dez(Naipe.Copa) 
                    }
                },
            };

        public static IEnumerable<object[]> DadosInvalidos =>
            new List<object[]>
            {
                new object[] { 
                    new List<Carta> {
                        new Sete(Naipe.Copa), new Seis(Naipe.Espadas), new Dois(Naipe.Copa), new Quatro(Naipe.Ouro), new Tres(Naipe.Ouro) 
                    }
                },
                new object[] { 
                    new List<Carta> {
                        new Sete(Naipe.Espadas), new Nove(Naipe.Copa), new Dez(Naipe.Copa), new Dama(Naipe.Paus), new Oito(Naipe.Espadas) 
                    }
                },
                new object[] { 
                    new List<Carta> {
                        new Rei(Naipe.Copa), new Nove(Naipe.Paus), new Dama(Naipe.Paus), new As(Naipe.Espadas), new Dez(Naipe.Copa) 
                    }
                },
            };
    }
}