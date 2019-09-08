using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeStraightFlush : Mao, IAnalisadorDeMao2
    {
        public Jogador ObterGanhador(Jogador jogador1, Jogador jogador2)
        {
            var jogador1PossuiUmStraightFlush = AnalisadorDeStraightFlush.EhUmaMaoValida(jogador1.Cartas);
            var jogador2PossuiUmStraightFlush = AnalisadorDeStraightFlush.EhUmaMaoValida(jogador2.Cartas);

            if (jogador1PossuiUmStraightFlush && !jogador2PossuiUmStraightFlush)
                return jogador1;

            if (jogador2PossuiUmStraightFlush && !jogador1PossuiUmStraightFlush)
                return jogador2;

            var maiorCartaDoJogador1 = ObterMaiorCartaDaMao(jogador1.Cartas);
            var maiorCartaDoJogador2 = ObterMaiorCartaDaMao(jogador2.Cartas);

            if (maiorCartaDoJogador1 > maiorCartaDoJogador2)
                return jogador1;
            
            return jogador2;
        }

        public static bool EhUmaMaoValida(IEnumerable<string> cartas)
        {
            var cartasSaoDoMesmoNaipe = cartas.GroupBy(m => m.Last()).Count() == 1;

            if (!cartasSaoDoMesmoNaipe)
                return false;

            var cartasOrdenadas = cartas.Select(ObterCartaSemNaipe).OrderBy(c => c).ToList();

            var valor = cartasOrdenadas.First();

            foreach (var carta in cartasOrdenadas)
            {
                if (valor != carta)
                    return false;
                
                valor++;
            }

            return true;
        }
    }
}