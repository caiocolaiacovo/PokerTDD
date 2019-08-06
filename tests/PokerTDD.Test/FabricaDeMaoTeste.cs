using System;
using System.Collections.Generic;
using PokerTDD.Cartas;
using PokerTDD.Maos;
using Xunit;

namespace PokerTDD.Test
{
    public class FabricaDeMaoTeste
    {
        [Fact]
        public void Deve_obter_uma_mao_do_tipo_royal_flush()
        {
            var naipe = Naipe.Espadas;
            var tipoEsperado = typeof(RoyalFlush);
            var cartas = new List<Carta> {
                new Dez(naipe),
                new Valete(naipe),
                new Dama(naipe),
                new Rei(naipe),
                new As(naipe)
            };

            var maoObtida = FabricaDeMao.ObterMao(cartas);

            Assert.IsType(tipoEsperado, maoObtida);
            Assert.True(maoObtida is Mao);
        }

        [Fact]
        public void Deve_obter_uma_mao_do_tipo_straight_flush()
        {
            var naipe = Naipe.Copa;
            var tipoEsperado = typeof(StraightFlush);
            var cartas = new List<Carta> {
                new Nove(naipe),
                new Sete(naipe),
                new Seis(naipe),
                new Oito(naipe),
                new Cinco(naipe)
            };

            var maoObtida = FabricaDeMao.ObterMao(cartas);

            Assert.IsType(tipoEsperado, maoObtida);
            Assert.True(maoObtida is Mao);
        }

        [Fact]
        public void Deve_obter_uma_mao_do_tipo_quadra()
        {
            var tipoEsperado = typeof(Quadra);
            var cartas = new List<Carta> {
                new Dama(Naipe.Copa),
                new Dama(Naipe.Espadas),
                new Dama(Naipe.Paus),
                new Dois(Naipe.Ouro),
                new Dama(Naipe.Ouro)
            };

            var maoObtida = FabricaDeMao.ObterMao(cartas);

            Assert.IsType(tipoEsperado, maoObtida);
            Assert.True(maoObtida is Mao);
        }
    }
}