using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class UmPar : Mao
    {
        public static bool ValidarUmPar(IEnumerable<string> maoDoJogador)
        {
            var cartasSemNaipe = maoDoJogador.Select(ObterCartaSemNaipe);

            var possuiUmPar = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 2).Count() == 1;
            var naoPossuiOutrasCartasRepetidas = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 1).Count() == 3;

            return possuiUmPar && naoPossuiOutrasCartasRepetidas;
        }
    }
}