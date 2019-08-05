using ExpectedObjects;
using PokerTDD.Cartas;
using Xunit;

namespace PokerTDD.Test.Cartas
{
    public class CartaAbstrataTeste
    {
        public int _valor { get; private set; }
        public Naipe _naipe { get; private set; }

        public class CartaAbstrata : Carta
        {
            public CartaAbstrata(int valor, Naipe naipe) : base(valor, naipe) { }
        }
        public CartaAbstrataTeste()
        {
            _valor = 1;
            _naipe = Naipe.Ouro;
        }

        [Fact]
        public void Deve_criar_uma_carta()
        {
            var cartaEsperada = new {
                Valor = _valor,
                Naipe = _naipe
            };

            var carta = new CartaAbstrata(_valor, _naipe);

            cartaEsperada.ToExpectedObject().ShouldMatch(carta);
        }

        [Fact]
        public void Deve_comparar_a_mesma_carta_usando_equals()
        {
            var carta1 = new CartaAbstrata(_valor, _naipe);
            var carta2 = new CartaAbstrata(_valor, _naipe);

            var iguais = carta1.Equals(carta2);

            Assert.True(iguais);
        }

        [Fact]
        public void Deve_comparar_duas_cartas_com_valores_diferentes_usando_equals()
        {
            const int valorCarta2 = 2;
            var carta1 = new CartaAbstrata(_valor, _naipe);
            var carta2 = new CartaAbstrata(valorCarta2, _naipe);

            var iguais = carta1.Equals(carta2);

            Assert.False(iguais);
        }

        [Fact]
        public void Deve_comparar_duas_cartas_com_naipes_diferentes_usando_equals()
        {
            var naipeCarta2 = Naipe.Espadas;
            var carta1 = new CartaAbstrata(_valor, _naipe);
            var carta2 = new CartaAbstrata(_valor, naipeCarta2);

            var iguais = carta1.Equals(carta2);

            Assert.False(iguais);
        }

        [Fact]
        public void Deve_comparar_uma_carta_com_ela_mesma_usando_equals()
        {
            var carta = new CartaAbstrata(_valor, _naipe);

            var iguais = carta.Equals(carta);

            Assert.True(iguais);
        }

        [Fact]
        public void Deve_comparar_uma_carta_com_nulo_usando_equals()
        {
            var carta = new CartaAbstrata(_valor, _naipe);

            var iguais = carta.Equals(null);

            Assert.False(iguais);
        }

        [Fact]
        public void Deve_comparar_a_mesma_carta_usando_o_operador_de_igual()
        {
            var carta1 = new CartaAbstrata(_valor, _naipe);
            var carta2 = new CartaAbstrata(_valor, _naipe);

            var iguais = carta1 == carta2;

            Assert.True(iguais);
        }

        [Fact]
        public void Deve_comparar_duas_cartas_com_valores_diferentes_usando_o_operador_de_igual()
        {
            const int valorDaCarta2 = 2;
            var carta1 = new CartaAbstrata(_valor, _naipe);
            var carta2 = new CartaAbstrata(valorDaCarta2, _naipe);

            var iguais = carta1 == carta2;

            Assert.False(iguais);
        }

        [Fact]
        public void Deve_comparar_duas_cartas_com_naipes_diferentes_usando_o_operador_de_igual()
        {
            var naipeDaCarta2 = Naipe.Paus;
            var carta1 = new CartaAbstrata(_valor, _naipe);
            var carta2 = new CartaAbstrata(_valor, naipeDaCarta2);

            var iguais = carta1 == carta2;

            Assert.False(iguais);
        }

        [Fact]
        public void Deve_comparar_a_carta_com_nulo_usando_o_operador_de_igual()
        {
            var iguais = (CartaAbstrata)null == null;

            Assert.True(iguais);
        }

        [Fact]
        public void Deve_comparar_cartas_com_valores_diferentes_usando_o_operador_de_diferente()
        {
            const int valorDaCarta2 = 2;
            var carta1 = new CartaAbstrata(_valor, _naipe);
            var carta2 = new CartaAbstrata(valorDaCarta2, _naipe);

            var diferentes = carta1 != carta2;

            Assert.True(diferentes);
        }

        [Fact]
        public void Deve_comparar_cartas_com_naipes_diferentes_usando_o_operador_de_diferente()
        {
            var carta1 = new CartaAbstrata(_valor, Naipe.Espadas);
            var carta2 = new CartaAbstrata(_valor, Naipe.Ouro);

            var diferentes = carta1 != carta2;

            Assert.True(diferentes);
        }
    }
}