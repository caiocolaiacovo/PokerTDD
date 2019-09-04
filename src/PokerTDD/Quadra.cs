using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class Quadra : Mao
    {
        public static bool ValidarQuadra(IEnumerable<string> maoDoJogador)
        {
            var cartasSemNaipe = maoDoJogador.Select(ObterCartaSemNaipe);

            var possuiQuatroCartasIguais = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 4).Any();

            return possuiQuatroCartasIguais;
        }
    }
}