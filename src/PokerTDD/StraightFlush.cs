using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class StraightFlush : Mao
    {
        public static bool ValidarStraightFlush(IEnumerable<string> maoDoJogador)
        {
            var cartasSaoDoMesmoNaipe = maoDoJogador.GroupBy(m => m.Last()).Count() == 1;

            if (!cartasSaoDoMesmoNaipe)
                return false;

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