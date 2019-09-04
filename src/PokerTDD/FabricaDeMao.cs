using System.Collections.Generic;

namespace PokerTDD
{
    public class FabricaDeMaos
    {
        public static Mao Criar(IEnumerable<string> cartas)
        {
            if (RoyalFlush.ValidarRoyalFlush(cartas))
                return new RoyalFlush();

            if (StraightFlush.ValidarStraightFlush(cartas))
                return new StraightFlush();

            if (Quadra.ValidarQuadra(cartas))
                return new Quadra();

            if (FullHouse.ValidarFullHouse(cartas))
                return new FullHouse();

            if (Flush.ValidarFlush(cartas))
                return new Flush();

            if (Straight.ValidarStraight(cartas))
                return new Straight();

            if (Trinca.ValidarTrinca(cartas))
                return new Trinca();

            if (DoisPares.ValidarDoisPares(cartas))
                return new DoisPares();

            if (UmPar.ValidarUmPar(cartas))
                return new UmPar();

            //carta alta

            return null;
        }
    }
}
