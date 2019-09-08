using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeTrinca : Mao
    {
        public static bool EhUmaMaoValida(IEnumerable<string> cartas)
        {
            var cartasSemNaipe = cartas.Select(ObterCartaSemNaipe);

            var possuiUmaTrinca = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 3).Any();
            var possuiUmPar = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 2).Any();

            return possuiUmaTrinca && !possuiUmPar;
        }
    }
}