using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class Flush : Mao
    {
        public static bool ValidarFlush(IEnumerable<string> maoDoJogador)
        {
            var cartasSaoDoMesmoNaipe = maoDoJogador.GroupBy(m => m.Last()).Count() == 1;

            return cartasSaoDoMesmoNaipe;
        }
    }
}