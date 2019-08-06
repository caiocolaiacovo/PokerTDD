using System.Collections.Generic;
using System.Linq;
using PokerTDD.Cartas;

namespace PokerTDD
{
    public class RoyalFlush : Mao
    {
        public RoyalFlush(List<Carta> cartas) : base((int)ValorDaMao.RoyalFlush, cartas) { }

        public static bool Validar(List<Carta> cartas)
        {
            if(!Flush.Validar(cartas))
                return false;

            var possuiUmDez = cartas.Any(c => c is Dez);
            var possuiUmValete = cartas.Any(c => c is Valete);
            var possuiUmaDama = cartas.Any(c => c is Dama);
            var possuiUmRei = cartas.Any(c => c is Rei);
            var possuiUmAs = cartas.Any(c => c is As);

            return possuiUmDez && possuiUmValete && possuiUmaDama && possuiUmRei && possuiUmAs;
        }
    }
}