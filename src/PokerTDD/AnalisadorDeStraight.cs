using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeStraight : Mao, IAnalisadorDeMao2
    {
        private static bool EhUmaMaoValida(IEnumerable<string> cartas)
        {
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

        public Jogador ObterGanhador(Jogador jogador1, Jogador jogador2)
        {
            var jogador1PossuiUmStraight = AnalisadorDeStraight.EhUmaMaoValida(jogador1.Cartas);
            var jogador2PossuiUmStraight = AnalisadorDeStraight.EhUmaMaoValida(jogador2.Cartas);

            if (jogador1PossuiUmStraight && !jogador2PossuiUmStraight)
                return jogador1;

            if (jogador2PossuiUmStraight && !jogador1PossuiUmStraight)
                return jogador2;

            var maiorCartaDoJogador1 = ObterMaiorCartaDaMao(jogador1.Cartas);
            var maiorCartaDoJogador2 = ObterMaiorCartaDaMao(jogador2.Cartas);

            if (maiorCartaDoJogador1 > maiorCartaDoJogador2)
                return jogador1;

            return jogador2;
        }
    }
}