using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeDoisPares : AnalisadorDeMaoBase, IAnalisadorDeMao
    {
        public int Ordem => 8;

        public bool EhValida(IEnumerable<string> cartas)
        {
            if (cartas == null || cartas.Count() == 0)
                throw new ArgumentException("É obrigatório informar uma mão para validar");
                
            var cartasSemNaipe = cartas.Select(ObterCartaSemNaipe);

            var possuiDoisPares = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 2).Count() == 2;

            return possuiDoisPares;
        }
    }
}