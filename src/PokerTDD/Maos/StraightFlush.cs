using System.Collections.Generic;
using PokerTDD.Cartas;

namespace PokerTDD.Maos
{
    public class StraightFlush : Mao
    {
        public StraightFlush(List<Carta> cartas) : base((int)ValorDaMao.StraightFlush, cartas) { }

        public static bool Validar(List<Carta> cartas)
        {
            return Flush.Validar(cartas) && Straight.Validar(cartas);
        }
    }
}
