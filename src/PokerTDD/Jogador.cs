using System.Collections.Generic;

namespace PokerTDD
{
    public class Jogador {
        public string Nome { get; set; }
        public IEnumerable<string> Cartas { get; set; }

        public Jogador(string nome, IEnumerable<string> cartas)
        {
            Nome = nome;
            Cartas = cartas;
        }
    }
}