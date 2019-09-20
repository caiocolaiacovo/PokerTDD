using System;
using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeTrincaTeste
    {
        public AnalisadorDeTrinca _analisador { get; private set; }

        public AnalisadorDeTrincaTeste()
        {
            _analisador = new AnalisadorDeTrinca();
        }

        [Fact]
        public void Deve_ser_um_analisador_de_mao()
        {
            Assert.True(_analisador is IAnalisadorDeMao);
            Assert.True(_analisador is AnalisadorDeMaoBase);
        }

        [Theory]
        [InlineData("3S", "2D", "3C", "7H", "3S")]
        [InlineData("KH", "KD", "3C", "7H", "KS")]
        [InlineData("AS", "2D", "3C", "AD", "AC")]
        [InlineData("10S", "10D", "10C", "7H", "3S")]
        [InlineData("AH", "AD", "AC", "QD", "JS")]
        public void Deve_ser_uma_mao_valida(
            string carta1, string carta2, string carta3, string carta4, string carta5
        )
        {
            var mao = new[] { 
                carta1,
                carta2,
                carta3,
                carta4,
                carta5
            };
            
            var ehValida = _analisador.EhValida(mao);

            Assert.True(ehValida);
        }

        [Theory]
        [InlineData("3S", "2D", "3C", "2H", "3S")]
        [InlineData("KH", "KD", "3C", "3H", "KS")]
        [InlineData("AS", "2D", "AC", "AD", "AC")]
        public void Nao_deve_ser_uma_mao_valida(
            string carta1, string carta2, string carta3, string carta4, string carta5
        )
        {
            var mao = new[] { 
                carta1,
                carta2,
                carta3,
                carta4,
                carta5
            };
            
            var ehValida = _analisador.EhValida(mao);

            Assert.False(ehValida);
        }

        [Fact]
        public void Deve_possuir_a_ordem_7()
        {
            const int ordemEsperada = 7;

            var ordem = _analisador.Ordem;

            Assert.Equal(ordemEsperada, ordem);
        }

        [Fact]
        public void Nao_deve_ser_uma_mao_valida_caso_seja_informada_uma_mao_vazia()
        {
            const string mensagemDeErroEsperada = "É obrigatório informar uma mão para validar";

            void Acao() => _analisador.EhValida(new string[]{});

            var mensagemDeErro = Assert.Throws<ArgumentException>(Acao).Message;
            Assert.Equal(mensagemDeErroEsperada, mensagemDeErro);
        }

        [Fact]
        public void Nao_deve_ser_uma_mao_valida_caso_seja_informada_uma_mao_nula()
        {
            const string mensagemDeErroEsperada = "É obrigatório informar uma mão para validar";

            void Acao() => _analisador.EhValida(null);

            var mensagemDeErro = Assert.Throws<ArgumentException>(Acao).Message;
            Assert.Equal(mensagemDeErroEsperada, mensagemDeErro);
        }
    }
}