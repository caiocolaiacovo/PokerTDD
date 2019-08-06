using System;
using System.Collections.Generic;
using PokerTDD.Cartas;
using Xunit;

namespace PokerTDD.Test
{
    public class FabricaDeMaoTeste
    {
        [Fact]
        public void Deve_obter_uma_mao_do_tipo_royal_flush()
        {
            var naipe = Naipe.Espadas;
            var cartas = new List<Carta> {
                new Dez(naipe),
                new Valete(naipe),
                new Dama(naipe),
                new Rei(naipe),
                new As(naipe)
            };

            var maoObtida = FabricaDeMao.ObterMao(cartas);

            Assert.IsType(typeof(RoyalFlush), maoObtida);
            Assert.True(maoObtida is Mao);
        }
    }
}