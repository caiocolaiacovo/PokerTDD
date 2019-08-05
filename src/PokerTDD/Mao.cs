using System.Collections.Generic;

namespace PokerTDD
{
    public class Mao
    {
        public IReadOnlyCollection<ICarta> Cartas { get; private set; }

        public Mao(ICarta carta1, ICarta carta2, ICarta carta3, ICarta carta4, ICarta carta5)
        {
            Cartas = new List<ICarta> { carta1, carta2, carta3, carta4, carta5 };
        }
    }
}