using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class FullHouse : Mao
    {
        public static bool ValidarFullHouse(IEnumerable<string> maoDoJogador)
        {
            var cartasSemNaipe = maoDoJogador.Select(ObterCartaSemNaipe);

            var cartasAgrupadasPorValor = cartasSemNaipe.GroupBy(c => c);

            var possuiUmaTrinca = cartasAgrupadasPorValor.Where(g => g.Count() == 3).Any();
            var possuiUmPar = cartasAgrupadasPorValor.Where(g => g.Count() == 2).Any();

            return possuiUmaTrinca && possuiUmPar;
        }
    }
}