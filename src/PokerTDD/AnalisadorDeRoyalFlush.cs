using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeRoyalFlush : AnalisadorDeMaoBase, IAnalisadorDeMao
    {
        public int Ordem => 1;

        public IAnalisadorDeMao AnalisadorDeFlush { get; }

        public AnalisadorDeRoyalFlush(IAnalisadorDeMao analisadorDeFlush)
        {
            AnalisadorDeFlush = analisadorDeFlush;
        }

        public bool EhValida(IEnumerable<string> cartas)
        {
            if (cartas == null || cartas.Count() == 0)
                throw new ArgumentException("É obrigatório informar uma mão para validar");

            var flushValido = AnalisadorDeFlush.EhValida(cartas);

            return flushValido && 
                cartas.Any(m => m.Contains("10")) &&
                cartas.Any(m => m.Contains("J")) &&
                cartas.Any(m => m.Contains("Q")) &&
                cartas.Any(m => m.Contains("K")) &&
                cartas.Any(m => m.Contains("A"));
        }
    }
}