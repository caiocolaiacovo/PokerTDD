using System;
using System.Collections.Generic;

namespace PokerTDD
{
    public abstract class Mao
    {
        public IEnumerable<string> Cartas { get; protected set; }

        public static int ObterCartaSemNaipe(string carta)
        {
            var cartaSemNaipe = carta.Remove(carta.Length - 1, 1);

            return ObterValorDaCarta(cartaSemNaipe);
        }

        public static int ObterValorDaCarta(string cartaSemNaipe)
        {
            if (cartaSemNaipe.Equals("J"))
                return 11;
            
            if (cartaSemNaipe.Equals("Q"))
                return 12;

            if (cartaSemNaipe.Equals("K"))
                return 13;
            
            if (cartaSemNaipe.Equals("A"))
                return 14;

            return Convert.ToInt32(cartaSemNaipe);
        }

        // public abstract int ObterMaiorCartaDaMao();
    }
}