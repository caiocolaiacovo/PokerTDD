namespace PokerTDD.Cartas
{
    public abstract class Carta
    {
        public int Valor { get; protected set; }
        public Naipe Naipe { get; protected set; }

        public Carta(int valor, Naipe naipe)
        {
            Valor = valor;
            Naipe = naipe;
        }

        public override bool Equals(object outro)
        {
            if (!(outro is Carta))
                return false;

            var carta = (Carta)outro;

            return Valor == carta.Valor && Naipe == carta.Naipe;
        }

        public override int GetHashCode()
        {
            return Valor;
        }

        public static bool operator ==(Carta a, Carta b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Carta a, Carta b)
        {
            return !(a == b);
        }
    }
}