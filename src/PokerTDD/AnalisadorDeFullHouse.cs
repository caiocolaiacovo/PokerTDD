using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeFullHouse : Mao, IAnalisadorDeMao2
    {
        public Jogador ObterGanhador(Jogador jogador1, Jogador jogador2)
        {
            var jogador1PossuiUmFullHouse = EhUmaMaoValida(jogador1.Cartas);
            var jogador2PossuiUmFullHouse = EhUmaMaoValida(jogador2.Cartas);

            if (jogador1PossuiUmFullHouse && !jogador2PossuiUmFullHouse)
                return jogador1;

            if (jogador2PossuiUmFullHouse && !jogador1PossuiUmFullHouse)
                return jogador2;

            var maiorCartaDoJogador1 = ObterMaiorCartaDaMao(jogador1.Cartas);
            var maiorCartaDoJogador2 = ObterMaiorCartaDaMao(jogador2.Cartas);

            if (maiorCartaDoJogador1 > maiorCartaDoJogador2)
                return jogador1;

            return jogador2;
        }

        protected override int ObterMaiorCartaDaMao(IEnumerable<string> maoDoJogador)
        {
            var cartasSemNaipe = maoDoJogador.Select(ObterCartaSemNaipe);

            var trinca = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 3).First();

            return trinca.First();
        }

        private static bool EhUmaMaoValida(IEnumerable<string> cartas)
        {
            var cartasSemNaipe = cartas.Select(ObterCartaSemNaipe);

            var cartasAgrupadasPorValor = cartasSemNaipe.GroupBy(c => c);

            var possuiUmaTrinca = cartasAgrupadasPorValor.Where(g => g.Count() == 3).Any();
            var possuiUmPar = cartasAgrupadasPorValor.Where(g => g.Count() == 2).Any();

            return possuiUmaTrinca && possuiUmPar;
        }
    }
}