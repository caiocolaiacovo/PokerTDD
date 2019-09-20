using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeStraightFlush : AnalisadorDeMaoBase, IAnalisadorDeMao
    {
        public int Ordem => 2;

        public IAnalisadorDeMao AnalisadorDeFlush { get; }
        public IAnalisadorDeMao AnalisadorDeStraight { get; }

        public AnalisadorDeStraightFlush(IAnalisadorDeMao analisadorDeFlush, IAnalisadorDeMao analisadorDeStraight)
        {
            AnalisadorDeFlush = analisadorDeFlush;
            AnalisadorDeStraight = analisadorDeStraight;
        }

        public bool EhValida(IEnumerable<string> cartas)
        {
            if (cartas == null || cartas.Count() == 0)
                throw new ArgumentException("É obrigatório informar uma mão para validar");
                
            var flushValido = AnalisadorDeFlush.EhValida(cartas);

            if (!flushValido)
                return false;

            return AnalisadorDeStraight.EhValida(cartas);
        }
    }
}