using System.Collections.Generic;
using System.Linq;
using PokerTDD.Cartas;

namespace PokerTDD
{
    public class StraightFlush
    {
        public static bool Validar(List<Carta> cartas)
        {
            var numeroDeNaipes = cartas.Select(c => c.Naipe).Distinct().Count();

            if (numeroDeNaipes > 1)
                return false;

            var cartasOrdenadas = cartas.OrderBy(c => c.Valor).ToList();
            var valorDaPrimeiraCarta = cartasOrdenadas.Select(c => c.Valor).First() - 1;
            var cartasEstaoEmSequencia = true;

            foreach (var carta in cartasOrdenadas)
            {
                valorDaPrimeiraCarta++;

                if (carta.Valor == valorDaPrimeiraCarta)
                    continue;

                cartasEstaoEmSequencia = false;
            }

            return cartasEstaoEmSequencia;
        }
    }
}
