using System.Collections.Generic;
using System.Linq;
using PokerTDD.Cartas;

namespace PokerTDD.Maos
{
    public class Quadra : Mao
    {
        public Quadra(List<Carta> cartas) : base((int)ValorDaMao.Quadra, cartas) { }

        public static bool Validar(List<Carta> cartas)
        {
            var grupos = cartas.GroupBy(c => c.Valor).Where(g => g.Count() == 4);

            return grupos.Count() == 1;
        }
    }
}
