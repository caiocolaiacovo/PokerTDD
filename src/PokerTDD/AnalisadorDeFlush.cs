using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeFlush: AnalisadorDeMaoBase, IAnalisadorDeMao
    {
        public int Ordem => 5;

        public bool EhValida(IEnumerable<string> cartas)
        {
            if (cartas == null || cartas.Count() == 0)
                throw new ArgumentException("É obrigatório informar uma mão para validar");
                
            var cartasSaoDoMesmoNaipe = cartas.GroupBy(m => m.Last()).Count() == 1;

            return cartasSaoDoMesmoNaipe;
        }
    }
}