using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeCartaAlta : AnalisadorDeMaoBase, IAnalisadorDeMao
    {
        public int Ordem => 10;

        public bool EhValida(IEnumerable<string> cartas)
        {
            if (cartas == null || cartas.Count() == 0)
                throw new ArgumentException("É obrigatório informar uma mão para validar");
                
            return true;
        }
    }
}