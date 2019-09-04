using System.Collections.Generic;

namespace PokerTDD
{
    public class Jogador {
        public string Nome { get; }
        public IEnumerable<string> Cartas { get; }
        public Mao Mao { get; }

        public Jogador(string nome, IEnumerable<string> cartas, Mao mao = null)
        {
            Nome = nome;
            Cartas = cartas;
            Mao = mao;
        }
    }
}