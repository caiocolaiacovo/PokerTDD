using System.Collections.Generic;
using ExpectedObjects;
using PokerTDD.Cartas;
using PokerTDD.Maos;
using Xunit;

namespace PokerTDD.Test.Maos
{
    public class RoyalFlushTeste
    {
        public static Naipe _naipe = Naipe.Paus;

        [Fact]
        public void Deve_criar_uma_mao()
        {
            var maoEsperada = new {
                Cartas = new List<Carta>(),
                Valor = (int)ValorDaMao.RoyalFlush
            };

            var mao = new RoyalFlush(new List<Carta>());

            maoEsperada.ToExpectedObject().ShouldMatch(mao);
        }

        [Fact]
        public void Deve_ser_uma_mao_valida()
        {
            var mao = new List<Carta> { 
                new As(_naipe),
                new Valete(_naipe),
                new Dez(_naipe),
                new Rei(_naipe),
                new Dama(_naipe)
            };

            var valido = RoyalFlush.Validar(mao);

            Assert.True(valido);
        }

        [Theory]
        [MemberData(nameof(MaosInvalidas))]
        public void Nao_deve_ser_uma_mao_valida(List<Carta> maoInvalida)
        {
            var valido = RoyalFlush.Validar(maoInvalida);

            Assert.False(valido);
        }

        public static IEnumerable<object[]> MaosInvalidas =>
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
            }
        };
    }
}