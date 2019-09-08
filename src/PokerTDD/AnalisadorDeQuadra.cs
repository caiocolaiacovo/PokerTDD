using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeQuadra : Mao, IAnalisadorDeMao2
    {
        public Jogador ObterGanhador(Jogador jogador1, Jogador jogador2)
        {
            var jogador1PossuiUmaQuadra = EhUmaMaoValida(jogador1.Cartas);
            var jogador2PossuiUmaQuadra = EhUmaMaoValida(jogador2.Cartas);

            if (jogador1PossuiUmaQuadra && !jogador2PossuiUmaQuadra)
                return jogador1;

            if (jogador2PossuiUmaQuadra && !jogador1PossuiUmaQuadra)
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

            var quadra = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 4).First();

            return quadra.First();
        }

        public static bool EhUmaMaoValida(IEnumerable<string> cartas)
        {
            var cartasSemNaipe = cartas.Select(ObterCartaSemNaipe);

            var possuiQuatroCartasIguais = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 4).Any();

            return possuiQuatroCartasIguais;
        }
    }
}