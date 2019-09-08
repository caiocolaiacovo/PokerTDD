using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeFlush : Mao, IAnalisadorDeMao2
    {
        public Jogador ObterGanhador(Jogador jogador1, Jogador jogador2)
        {
            var jogador1PossuiUmFlush = EhUmaMaoValida(jogador1.Cartas);
            var jogador2PossuiUmFlush = EhUmaMaoValida(jogador2.Cartas);

            if (jogador1PossuiUmFlush && !jogador2PossuiUmFlush)
                return jogador1;

            if (jogador2PossuiUmFlush && !jogador1PossuiUmFlush)
                return jogador2;

            var maiorCartaDoJogador1 = ObterMaiorCartaDaMao(jogador1.Cartas);
            var maiorCartaDoJogador2 = ObterMaiorCartaDaMao(jogador2.Cartas);

            if (maiorCartaDoJogador1 > maiorCartaDoJogador2)
                return jogador1;

            return jogador2;
        }

        private static bool EhUmaMaoValida(IEnumerable<string> cartas)
        {
            var cartasSaoDoMesmoNaipe = cartas.GroupBy(m => m.Last()).Count() == 1;

            return cartasSaoDoMesmoNaipe;
        }
    }
}