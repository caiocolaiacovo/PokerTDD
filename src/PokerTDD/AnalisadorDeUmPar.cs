using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeUmPar : AnalisadorDeMaoBase, IAnalisadorDeMao
    {
        public int Ordem => 9;

        public bool EhValida(IEnumerable<string> cartas)
        {
            if (cartas == null || cartas.Count() == 0)
                throw new ArgumentException("É obrigatório informar uma mão para validar");
                
            var cartasSemNaipe = cartas.Select(ObterCartaSemNaipe);

            var possuiUmPar = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 2).Count() == 1;
            var naoPossuiOutrasCartasRepetidas = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 1).Count() == 3;

            return possuiUmPar && naoPossuiOutrasCartasRepetidas;
        }
    }
}