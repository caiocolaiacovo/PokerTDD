using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class RoyalFlush : Mao
    {
        public static bool ValidarRoyalFlush(IEnumerable<string> maoDoJogador)
        {
            var cartasSaoDoMesmoNaipe = maoDoJogador.GroupBy(m => m.Last()).Count() == 1;

            return cartasSaoDoMesmoNaipe && 
                maoDoJogador.Any(m => m.Contains("10")) &&
                maoDoJogador.Any(m => m.Contains("J")) &&
                maoDoJogador.Any(m => m.Contains("Q")) &&
                maoDoJogador.Any(m => m.Contains("K")) &&
                maoDoJogador.Any(m => m.Contains("A"));
        }
    }
}