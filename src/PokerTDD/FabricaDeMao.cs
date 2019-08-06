using System.Collections.Generic;
using PokerTDD.Cartas;

namespace PokerTDD
{
    public class FabricaDeMao
    {
        public static Mao ObterMao(List<Carta> cartas)
        {
            if (RoyalFlush.Validar(cartas))
                return new RoyalFlush(cartas);

            return null;
        }
    }
}