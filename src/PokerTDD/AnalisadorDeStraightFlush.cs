using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeStraightFlush : AnalisadorDeMaoBase, IAnalisadorDeMao
    {
        public int Ordem => 2;

        public IAnalisadorDeMao AnalisadorDeFlush { get; set; }

        public AnalisadorDeStraightFlush(IAnalisadorDeMao analisadorDeFlush)
        {
            AnalisadorDeFlush = analisadorDeFlush;
        }

        public bool EhValida(IEnumerable<string> cartas)
        {
            var flushValido = AnalisadorDeFlush.EhValida(cartas);

            if (!flushValido)
                return false;

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