using System.Collections.Generic;
using ExpectedObjects;
using PokerTDD.Cartas;
using PokerTDD.Maos;
using Xunit;

namespace PokerTDD.Test.Maos
{
    public class CartaAltaTeste
    {
        // [Fact]
        // public void Deve_retornar_a_carta_de_maior_valor()
        // {
        //     var naipe = Naipe.Ouro;
        //     var cartaEsperada = new Seis(naipe);

        //     var valor = CartaAlta.MaiorValor(new List<ICarta> { 
        //         new Cinco(naipe), 
        //         new Dois(naipe), 
        //         new Quatro(naipe), 
        //         new Seis(naipe), 
        //         new Tres(naipe) 
        //     });

        //     Assert.Equal(cartaEsperada.Valor, valor);
        // }

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
    }
}