using System.Collections.Generic;

namespace PokerTDD
{
    public interface IAnalisadorDeMao
    {
    }

    public interface IAnalisadorDeMao2
    {
        Jogador ObterGanhador(Jogador jogador1, Jogador jogador2);
    }
}