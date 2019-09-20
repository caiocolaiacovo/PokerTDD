using System;
using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeUmParTeste
    {
        public AnalisadorDeUmPar _analisador { get; private set; }

        public AnalisadorDeUmParTeste()
        {
            _analisador = new AnalisadorDeUmPar();
        }

        [Fact]
        public void Deve_ser_um_analisador_de_mao()
        {
            Assert.True(_analisador is IAnalisadorDeMao);
            Assert.True(_analisador is AnalisadorDeMaoBase);
        }

        [Theory]
        [InlineData("QS", "2D", "QC", "10H", "3S")]
        [InlineData("AH", "AD", "KC", "QD", "JS")]
        [InlineData("4D", "KD", "QC", "2H", "2S")]
        [InlineData("6H", "AD", "KC", "QD", "QS")]
        [InlineData("7S", "3D", "8C", "KD", "KC")]
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
        [InlineData("2S", "2D", "10C", "10H", "AS")]
        [InlineData("KH", "AD", "KC", "KD", "KS")]
        [InlineData("4D", "10D", "KC", "JH", "QS")]
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
        public void Deve_possuir_a_ordem_9()
        {
            const int ordemEsperada = 9;

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