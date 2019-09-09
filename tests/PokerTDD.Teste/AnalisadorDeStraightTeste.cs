using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeStraightTeste
    {
        private AnalisadorDeStraight _analisador;

        public AnalisadorDeStraightTeste()
        {
            _analisador = new AnalisadorDeStraight();
        }

        [Theory]
        [InlineData("2C", "6D", "5H", "3S", "4C")]
        [InlineData("9C", "8D", "7S", "6H", "10H")]
        [InlineData("10D", "QC", "KD", "JH", "9C")]
        [InlineData("7H", "JC", "8C", "9D", "10S")]
        [InlineData("3S", "2D", "6C", "4H", "5S")]
        public void Deve_ser_uma_mao_valida(
            string carta1, string carta2, string carta3, string carta4, string carta5
        )
        {
            var mao = new[]
            {
                carta1,
                carta2,
                carta3,
                carta4,
                carta5
            };
            var ehValida = _analisador.EhValida(mao);

            Assert.True(ehValida);
        }
    }
}
