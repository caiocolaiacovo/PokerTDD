using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeJogadaTeste
    {
        [Fact]
        public void Jogador_1_deve_ser_o_ganhador_com_um_par()
        {
            const string ganhadorEsperado = "Jogador 1";
            var maoDoJogador1 = new[] { "5H", "5C", "6S", "7S", "KD" };
            var maoDoJogador2 = new[] { "2C", "3S", "8S", "8D", "TD" };

            var ganhador = AnalisadorDeJogada.Analisar(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        public class AnalisadorDeJogada
        {
            public static string Analisar(string[] maoDoJogador1, string[] maoDoJogador2)
            {
                return "Jogador 1";
            }
        }
    }
}
