using System.Collections.Generic;
using System.Linq;
using PokerTDD.Cartas;

namespace PokerTDD.Maos
{
    public class CartaAlta : Mao
    {
        public CartaAlta(List<Carta> cartas) : base((int)ValorDaMao.CartaAlta, cartas)
        {
            CartaMaisAlta = ObterCartaMaisAlta();
        }

        private Carta ObterCartaMaisAlta()
        {
            return Cartas.OrderByDescending(c => c.Valor).First();
        }
    }
}