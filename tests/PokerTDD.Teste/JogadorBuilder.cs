using System.Collections.Generic;
using System.Linq;

namespace PokerTDD.Teste
{
    public class JogadorBuilder {
        private List<string> Cartas = new List<string>();

        private string Nome = "Jogador 1";

        public static JogadorBuilder Instancia()
        {
            return new JogadorBuilder();
        }

        public JogadorBuilder ComNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public JogadorBuilder ComCartas(List<string> cartas)
        {
            Cartas = cartas;
            return this;
        }

        public JogadorBuilder ComCartas(IEnumerable<string> cartas)
        {
            Cartas = cartas.ToList();
            return this;
        }

        public Jogador Construir()
        {
            return new Jogador(Nome, Cartas);
        }
    }
}