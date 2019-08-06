using System.Collections.Generic;
using ExpectedObjects;
using PokerTDD.Cartas;
using PokerTDD.Maos;
using Xunit;

namespace PokerTDD.Test.Maos
{
    public class FlushTeste
    {
        public static Naipe _naipe = Naipe.Copa;

        [Fact]
        public void Deve_criar_uma_mao()
        {
            var maoEsperada = new {
                Cartas = new List<Carta>(),
                Valor = (int)ValorDaMao.Flush
            };

            var mao = new Flush(new List<Carta>());

            maoEsperada.ToExpectedObject().ShouldMatch(mao);
        }

        [Theory]
        [MemberData(nameof(MaosValidas))]
        public void Deve_ser_uma_mao_valida(List<Carta> maoValida)
        {
            var valida = Flush.Validar(maoValida);

            Assert.True(valida);
        }

        [Theory]
        [MemberData(nameof(MaosInvalidas))]
        public void Deve_ser_uma_mao_invalida(List<Carta> maoInvalida)
        {
            var valida = Flush.Validar(maoInvalida);

            Assert.False(valida);
        }

        public static IEnumerable<object[]> MaosValidas =>
            new List<object[]>
            {
                new object[] { 
                    new List<Carta> {
                        new Dois(_naipe), new Dama(_naipe), new Sete(_naipe), new As(_naipe), new Valete(_naipe) 
                    }
                },
                new object[] { 
                    new List<Carta> {
                        new Rei(_naipe), new Quatro(_naipe), new Cinco(_naipe), new Seis(_naipe), new Dama(_naipe) 
                    }
                },
                new object[] { 
                    new List<Carta> {
                        new As(_naipe), new Valete(_naipe), new Dez(_naipe), new Rei(_naipe), new Dama(_naipe) 
                    }
                }
            };

        public static IEnumerable<object[]> MaosInvalidas =>
            new List<object[]>
            {
                new object[] { 
                    new List<Carta> {
                        new Dois(Naipe.Espadas), new Dama(_naipe), new Sete(_naipe), new As(_naipe), new Valete(_naipe) 
                    }
                },
                new object[] { 
                    new List<Carta> {
                        new Rei(_naipe), new Quatro(_naipe), new Cinco(Naipe.Espadas), new Seis(_naipe), new Dama(_naipe) 
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