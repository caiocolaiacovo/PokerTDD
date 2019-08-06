using System.Collections.Generic;
using PokerTDD.Cartas;

namespace PokerTDD.Maos
{
    public abstract class Mao
    {
        public int Valor { get; private set; }
        public IReadOnlyCollection<Carta> Cartas { get; protected set; }

        public Mao(int valor, List<Carta> cartas)
        {
            Valor = valor;
            Cartas = cartas;
        }
    }

    public interface IMao
    {
    }
}