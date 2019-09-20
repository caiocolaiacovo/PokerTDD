using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeFullHouse : AnalisadorDeMaoBase, IAnalisadorDeMao
    {
        public int Ordem => 4;

        public IAnalisadorDeMao AnalisadorDeTrinca { get; }

        public IAnalisadorDeMao AnalisadorDePar { get; }

        public AnalisadorDeFullHouse(IAnalisadorDeMao analisadorDeTrinca, IAnalisadorDeMao analisadorDePar)
        {
            AnalisadorDeTrinca = analisadorDeTrinca;
            AnalisadorDePar = analisadorDePar;
        }

        public override int ObterMaiorCartaDaMao(IEnumerable<string> maoDoJogador)
        {
            var cartasSemNaipe = maoDoJogador.Select(ObterCartaSemNaipe);

            var trinca = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 3).First();

            return trinca.First();
        }

        public bool EhValida(IEnumerable<string> cartas)
        {
            if (cartas == null || cartas.Count() == 0)
                throw new ArgumentException("É obrigatório informar uma mão para validar");
            
            var possuiUmaTrinca = AnalisadorDeTrinca.EhValida(cartas);
            var possuiUmPar = AnalisadorDePar.EhValida(cartas);

            return possuiUmaTrinca && possuiUmPar;
        }
    }
}