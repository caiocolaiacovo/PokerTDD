using System.Collections.Generic;
using System.Linq;
using PokerTDD.Cartas;

namespace PokerTDD
{
    public class RoyalFlush
    {
        public static bool Validar(List<Carta> cartas)
        {
            var numeroDeNaipes = cartas.Select(c => c.Naipe).Distinct().Count();

            if (numeroDeNaipes > 1)
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