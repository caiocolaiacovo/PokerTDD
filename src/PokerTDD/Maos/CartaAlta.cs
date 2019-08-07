using System.Collections.Generic;
using System.Linq;
using PokerTDD.Cartas;

namespace PokerTDD.Maos
{
    public class CartaAlta : Mao
    {
        public CartaAlta(List<Carta> cartas) : base((int)ValorDaMao.CartaAlta, cartas)
        {
        }

        public static int MaiorValor(List<Carta> list)
        {
            return list.OrderByDescending(c => c.Valor).Select(c => c.Valor).First();
        }
    }
}