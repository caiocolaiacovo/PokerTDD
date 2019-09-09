using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeStraightFlush : AnalisadorDeMaoBase, IAnalisadorDeMao
    {
        public int Ordem => 2;

        public bool EhValida(IEnumerable<string> cartas)
        {
            var cartasSaoDoMesmoNaipe = cartas.GroupBy(m => m.Last()).Count() == 1;

            if (!cartasSaoDoMesmoNaipe)
                return false;

            var cartasOrdenadas = cartas.Select(ObterCartaSemNaipe).OrderBy(c => c).ToList();

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