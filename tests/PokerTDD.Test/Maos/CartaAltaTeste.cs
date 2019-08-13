using System.Collections.Generic;
using ExpectedObjects;
using PokerTDD.Cartas;
using PokerTDD.Maos;
using Xunit;

namespace PokerTDD.Test.Maos
{
    public class CartaAltaTeste
    {
        [Fact]
        public void Deve_criar_uma_mao()
        {
            var naipe = Naipe.Espadas;
            var cartas = new List<Carta>
            {
                new Dois(naipe),
                new Seis(naipe),
                new Sete(naipe),
                new Dama(naipe),
                new Rei(naipe)
            };
            var maoEsperada = new
            {
                Cartas = cartas,
                Valor = (int)ValorDaMao.CartaAlta
            };

            var mao = new CartaAlta(cartas);

            maoEsperada.ToExpectedObject().ShouldMatch(mao);
        }

        [Fact]
        public void Deve_obter_o_valor_da_carta_mais_alta_ao_criar_a_mao()
        {
            var naipe = Naipe.Ouro;
            var cartaEsperada = new Dama(naipe);

            var mao = new CartaAlta(new List<Carta> {
                     new Seis(naipe),
                     new Dois(naipe),
                     new Quatro(naipe),
                     new Dama(naipe),
                     new Valete(naipe)
                 });

            Assert.Equal(cartaEsperada.Valor, mao.ValorDaCartaMaisAlta);
        }
    }
}