using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeTrinca : AnalisadorDeMaoBase, IAnalisadorDeMao
    {
        public int Ordem => 7;

        public bool EhValida(IEnumerable<string> cartas)
        {
            if (cartas == null || cartas.Count() == 0)
                throw new ArgumentException("É obrigatório informar uma mão para validar");
                
            var cartasSemNaipe = cartas.Select(ObterCartaSemNaipe);

            var possuiUmaTrinca = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 3).Any();
            var possuiUmPar = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 2).Any();

            return possuiUmaTrinca && !possuiUmPar;
        }
    }
}