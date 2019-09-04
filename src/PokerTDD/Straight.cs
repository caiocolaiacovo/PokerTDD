using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class Straight : Mao
    {
        public static bool ValidarStraight(IEnumerable<string> maoDoJogador)
        {
            var cartasOrdenadas = maoDoJogador.Select(ObterCartaSemNaipe).OrderBy(c => c).ToList();

            var valor = cartasOrdenadas.First();

            foreach (var carta in cartasOrdenadas)
            {
                if (valor != carta)
                    return false;
                
                valor++;
            }

            return true;
        }
    }
}