using System;
using System.Collections.Generic;
using System.Linq;
using PokerTDD.Cartas;

namespace PokerTDD.Maos
{
    public abstract class Mao
    {
        public int Valor { get; private set; }
        public IReadOnlyCollection<Carta> Cartas { get; protected set; }
        protected Carta CartaMaisAlta { get; set; }

        protected Mao(int valor, List<Carta> cartas)
        {
            if (valor <= 0)
                throw new Exception("É obrigatório informar o Valor");

            if (cartas == null || !cartas.Any())
                throw new Exception("É obrigatório informar as Cartas");

            Valor = valor;
            Cartas = cartas;
        }

        public int ValorDaCartaMaisAlta => CartaMaisAlta?.Valor ?? 0;

        // protected abstract int ObterCartaMaisAltaNaMao();
        // protected abstract int ValorDaCartaMaisAltaNaMao();
    }

    public interface IMao
    {
    }
}