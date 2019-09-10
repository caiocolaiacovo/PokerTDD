using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeFullHouse : AnalisadorDeMaoBase, IAnalisadorDeMao
    {
        public int Ordem => 4;

        public IAnalisadorDeMao AnalisadorDeTrinca { get; }

        public AnalisadorDeFullHouse(IAnalisadorDeMao analisadorDeTrinca)
        {
            AnalisadorDeTrinca = analisadorDeTrinca;
        }

        public override int ObterMaiorCartaDaMao(IEnumerable<string> maoDoJogador)
        {
            var cartasSemNaipe = maoDoJogador.Select(ObterCartaSemNaipe);

            var trinca = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 3).First();

            return trinca.First();
        }

        public bool EhValida(IEnumerable<string> cartas)
        {
            var cartasSemNaipe = cartas.Select(ObterCartaSemNaipe);

            var cartasAgrupadasPorValor = cartasSemNaipe.GroupBy(c => c);

            var possuiUmaTrinca = cartasAgrupadasPorValor.Where(g => g.Count() == 3).Any();
            var possuiUmPar = cartasAgrupadasPorValor.Where(g => g.Count() == 2).Any();

            return possuiUmaTrinca && possuiUmPar;
        }
    }
}