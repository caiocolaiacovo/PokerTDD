using PokerTDD.Cartas;
using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class Quadra
    {
        public static bool Validar(List<Carta> cartas)
        {
            var grupos = cartas.GroupBy(c => c.Valor).Where(g => g.Count() == 4);

            return grupos.Count() == 1;
        }
    }
}
