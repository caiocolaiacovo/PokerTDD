using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class Trinca : Mao
    {
        public static bool ValidarTrinca(IEnumerable<string> maoDoJogador)
        {
            var cartasSemNaipe = maoDoJogador.Select(ObterCartaSemNaipe);

            var possuiUmaTrinca = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 3).Any();
            var possuiUmPar = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 2).Any();

            return possuiUmaTrinca && !possuiUmPar;
        }
    }
}