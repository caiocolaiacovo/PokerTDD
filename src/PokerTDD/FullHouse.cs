using System;
using System.Collections.Generic;
using PokerTDD.Cartas;

namespace PokerTDD
{
    public class FullHouse : Mao
    {
        public FullHouse(List<Carta> cartas) 
            : base(1, cartas)
        {
        }

        public static bool Validar(List<Carta> cartas)
        {
            throw new NotImplementedException();
        }
    }
}