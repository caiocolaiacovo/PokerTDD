using System.Collections.Generic;
using PokerTDD.Cartas;
using PokerTDD.Maos;

namespace PokerTDD
{
    public class FabricaDeMao
    {
        public static Mao ObterMao(List<Carta> cartas)
        {
            if (RoyalFlush.Validar(cartas))
                return new RoyalFlush(cartas);

            if (StraightFlush.Validar(cartas))
                return new StraightFlush(cartas);

            if (Quadra.Validar(cartas))
                return new Quadra(cartas);

            return null;
        }
    }
}