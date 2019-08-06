using System.Collections.Generic;
using System.Linq;
using PokerTDD.Cartas;

namespace PokerTDD
{
    public class Flush : Mao
    {
        public Flush(List<Carta> cartas) : base((int)ValorDaMao.Flush, cartas) { }

        public static bool Validar(List<Carta> cartas)
        {
            var numeroDeNaipes = cartas.Select(c => c.Naipe).Distinct().Count();

            return numeroDeNaipes == 1;
        }
    }
}