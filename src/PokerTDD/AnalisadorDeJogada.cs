using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeJogada
    {
        public IEnumerable<IAnalisadorDeMao> AnalisadoresDeMao { get; }

        public AnalisadorDeJogada(IEnumerable<IAnalisadorDeMao> analisadoresDeMao)
        {
            AnalisadoresDeMao = OrdenarAnalisadores(analisadoresDeMao);
        }

        private IEnumerable<IAnalisadorDeMao> OrdenarAnalisadores(IEnumerable<IAnalisadorDeMao> analisadoresDeMao)
        {
            return analisadoresDeMao.OrderBy(a => a.Ordem);
        }

        public string ObterGanhador(IEnumerable<string> maoDoJogador1, IEnumerable<string> maoDoJogador2)
        {
            foreach (var analisador in AnalisadoresDeMao)
            {
                var jogador1PossuiMaoValida = analisador.EhValida(maoDoJogador1);
                var jogador2PossuiMaoValida = analisador.EhValida(maoDoJogador2);

                if (!jogador1PossuiMaoValida && !jogador2PossuiMaoValida)
                    continue;

                if (jogador1PossuiMaoValida && !jogador2PossuiMaoValida)
                    return "Jogador 1";

                if (jogador2PossuiMaoValida && !jogador1PossuiMaoValida)
                    return "Jogador 2";

                var maiorCartaDoJogador1 = analisador.ObterMaiorCartaDaMao(maoDoJogador1);
                var maiorCartaDoJogador2 = analisador.ObterMaiorCartaDaMao(maoDoJogador2);

                if (maiorCartaDoJogador1 == maiorCartaDoJogador2)
                    break;

                if (maiorCartaDoJogador1 > maiorCartaDoJogador2)
                    return "Jogador 1";
                
                return  "Jogador 2";
            }

            return "Nenhum";
        }
    }
}