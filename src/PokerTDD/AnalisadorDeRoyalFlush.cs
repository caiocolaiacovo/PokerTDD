using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeRoyalFlush : Mao, IAnalisadorDeMao2
    {
        public Jogador ObterGanhador(Jogador jogador1, Jogador jogador2)
        {
            var jogador1PossuiUmRoyalFlush = EhUmaMaoValida(jogador1.Cartas);
            var jogador2PossuiUmRoyalFlush = EhUmaMaoValida(jogador2.Cartas);

            if (jogador1PossuiUmRoyalFlush && !jogador2PossuiUmRoyalFlush)
                return jogador1;

            if (jogador2PossuiUmRoyalFlush && !jogador1PossuiUmRoyalFlush)
                return jogador2;

            return null;
        }
        private bool EhUmaMaoValida(IEnumerable<string> cartas)
        {
            var cartasSaoDoMesmoNaipe = cartas.GroupBy(m => m.Last()).Count() == 1;

            return cartasSaoDoMesmoNaipe && 
                cartas.Any(m => m.Contains("10")) &&
                cartas.Any(m => m.Contains("J")) &&
                cartas.Any(m => m.Contains("Q")) &&
                cartas.Any(m => m.Contains("K")) &&
                cartas.Any(m => m.Contains("A"));
        }
    }
}