using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeDoisPares : Mao, IAnalisadorDeMao
    {
        public static bool EhUmaMaoValida(IEnumerable<string> cartas)
        {
            var cartasSemNaipe = cartas.Select(ObterCartaSemNaipe);

            var possuiDoisPares = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 2).Count() == 2;

            return possuiDoisPares;
        }
    }
}