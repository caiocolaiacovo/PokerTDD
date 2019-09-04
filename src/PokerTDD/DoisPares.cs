using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class DoisPares : Mao
    {
        public static bool ValidarDoisPares(IEnumerable<string> maoDoJogador)
        {
            var cartasSemNaipe = maoDoJogador.Select(ObterCartaSemNaipe);

            var possuiDoisPares = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 2).Count() == 2;

            return possuiDoisPares;
        }
    }
}