using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class CartaAlta
    {
        public static int MaiorValor(List<ICarta> list)
        {
            return list.OrderByDescending(c => c.Valor).Select(c => c.Valor).First();
        }
    }
}