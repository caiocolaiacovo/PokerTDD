using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeUmPar : Mao
    {
        public static bool EhUmaMaoValida(IEnumerable<string> cartas)
        {
            var cartasSemNaipe = cartas.Select(ObterCartaSemNaipe);

            var possuiUmPar = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 2).Count() == 1;
            var naoPossuiOutrasCartasRepetidas = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 1).Count() == 3;

            return possuiUmPar && naoPossuiOutrasCartasRepetidas;
        }
    }
}