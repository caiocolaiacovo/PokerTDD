using System.Collections.Generic;
using System.Linq;
using PokerTDD.Cartas;

namespace PokerTDD.Maos
{
    public class Par : Mao
    {
        public Par(List<Carta> cartas) : base((int)ValorDaMao.Par, cartas) { }

        public static bool Validar(List<Carta> cartas)
        {
            var gruposDeCartas = cartas.GroupBy(c => c.Valor).Where(g => g.Count() == 2);

            return gruposDeCartas.Count() == 1;
        }
    }
}