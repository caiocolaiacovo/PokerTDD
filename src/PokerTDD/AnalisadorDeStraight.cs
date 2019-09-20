using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerTDD
{
    public class AnalisadorDeStraight : AnalisadorDeMaoBase, IAnalisadorDeMao
    {
        public int Ordem => 6;
        
        public bool EhValida(IEnumerable<string> cartas)
        {
            if (cartas == null || cartas.Count() == 0)
                throw new ArgumentException("É obrigatório informar uma mão para validar");
                
            var cartasOrdenadas = cartas.Select(ObterCartaSemNaipe).OrderBy(c => c).ToList();

            var valor = cartasOrdenadas.First();

            foreach (var carta in cartasOrdenadas)
            {
                if (valor != carta)
                    return false;

                valor++;
            }

            return true;
        }
    }
}
