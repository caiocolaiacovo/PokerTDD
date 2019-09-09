using System.Collections.Generic;

namespace PokerTDD
{
    public interface IAnalisadorDeMao
    {
        int Ordem { get; }
        bool EhValida(IEnumerable<string> collection);
        int ObterMaiorCartaDaMao(IEnumerable<string> maoDoJogador);
    }
}