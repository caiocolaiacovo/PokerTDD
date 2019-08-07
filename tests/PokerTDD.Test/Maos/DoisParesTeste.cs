using System.Collections.Generic;
using ExpectedObjects;
using PokerTDD.Cartas;
using PokerTDD.Maos;
using Xunit;

namespace PokerTDD.Test.Maos
{
    public class DoisParesTeste
    {
        [Fact]
        public void Deve_criar_uma_mao()
        {
            var maoEsperada = new
            {
                Cartas = new List<Carta>(),
                Valor = (int)ValorDaMao.DoisPares
            };

            var mao = new DoisPares(new List<Carta>());

            maoEsperada.ToExpectedObject().ShouldMatch(mao);
        }

        [Theory]
        [MemberData(nameof(DadosValidos))]
        public void Deve_ser_valido(List<Carta> cartas)
        {
            var valido = DoisPares.Validar(cartas);

            Assert.True(valido);
        }

        [Theory]
        [MemberData(nameof(DadosInvalidos))]
        public void Deve_ser_invalido(List<Carta> cartas)
        {
            var valido = DoisPares.Validar(cartas);

            Assert.False(valido);
        }

        public static IEnumerable<object[]> DadosValidos =>
            new List<object[]>
            {
                new object[] { 
                    new List<Carta> {
                        new Cinco(Naipe.Copa), new As(Naipe.Espadas), new Dama(Naipe.Copa), new As(Naipe.Ouro), new Dama(Naipe.Ouro) 
                    }
                },
                new object[] { 
                    new List<Carta> {
                        new Sete(Naipe.Espadas), new Sete(Naipe.Copa), new Dez(Naipe.Copa), new Dez(Naipe.Paus), new Rei(Naipe.Espadas) 
                    }
                },
                new object[] { 
                    new List<Carta> {
                        new Rei(Naipe.Copa), new Rei(Naipe.Paus), new Dama(Naipe.Paus), new Dama(Naipe.Espadas), new As(Naipe.Copa) 
                    }
                },
            };

        public static IEnumerable<object[]> DadosInvalidos =>
            new List<object[]>
            {
                new object[] { 
                    new List<Carta> {
                        new Sete(Naipe.Copa), new Sete(Naipe.Espadas), new Dama(Naipe.Copa), new Valete(Naipe.Ouro), new As(Naipe.Ouro) 
                    }
                },
                new object[] { 
                    new List<Carta> {
                        new Rei(Naipe.Espadas), new As(Naipe.Copa), new As(Naipe.Ouro), new As(Naipe.Paus), new As(Naipe.Espadas) 
                    }
                },
                new object[] { 
                    new List<Carta> {
                        new Sete(Naipe.Copa), new Dois(Naipe.Paus), new Nove(Naipe.Paus), new Cinco(Naipe.Espadas), new As(Naipe.Copa) 
                    }
                },
            };
    }
}
