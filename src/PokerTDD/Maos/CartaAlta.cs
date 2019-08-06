using System.Collections.Generic;
using System.Linq;
using PokerTDD.Cartas;

namespace PokerTDD.Maos
{
    public class CartaAlta
    {
        public static int MaiorValor(List<Carta> list)
        {
            return list.OrderByDescending(c => c.Valor).Select(c => c.Valor).First();
        }
    }
}