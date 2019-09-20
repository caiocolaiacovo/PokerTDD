using System;
using Moq;
using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeFullHouseTeste
    {
        public Mock<IAnalisadorDeMao> _analisadorDeTrinca { get; }
        public Mock<IAnalisadorDeMao> _analisadorDePar { get; }
        public AnalisadorDeFullHouse _analisador { get; }

        public AnalisadorDeFullHouseTeste()
        {
            _analisadorDeTrinca = new Mock<IAnalisadorDeMao>();
            _analisadorDePar = new Mock<IAnalisadorDeMao>();
            
            _analisador = new AnalisadorDeFullHouse(
                _analisadorDeTrinca.Object, _analisadorDePar.Object);
        }

        [Fact]
        public void Deve_invocar_o_analisador_de_trinca_ao_validar_uma_mao()
        {
            var mao = new string[] {"2D", "6H", "6C", "2S", "2H"};

            _analisador.EhValida(mao);

            _analisadorDeTrinca.Verify(a => a.EhValida(mao));
        }

        [Fact]
        public void Deve_invocar_o_analisador_de_par_ao_validar_uma_mao()
        {
            var mao = new string[] {"2D", "6H", "6C", "2S", "2H"};

            _analisador.EhValida(mao);

            _analisadorDePar.Verify(a => a.EhValida(mao));
        }

        [Theory]
        [InlineData(true, false)]
        [InlineData(false, true)]
        public void Deve_ser_invalida_caso_os_analisadores_falhem(
            bool validacaoDoAnalisadorDeTrinca, bool validacaoDoAnalisadorDePar)
        {
            var mao = new string[] { "AH", "AC", "AS", "QC", "QD" };
            _analisadorDeTrinca.Setup(a => a.EhValida(mao)).Returns(validacaoDoAnalisadorDeTrinca);
            _analisadorDePar.Setup(a => a.EhValida(mao)).Returns(validacaoDoAnalisadorDePar);

            var ehValida = _analisador.EhValida(mao);

            Assert.False(ehValida);
        }

        [Fact]
        public void Deve_ser_uma_mao_valida()
        {
            var mao = new string[] { "AH", "AC", "AS", "QC", "QD" };
            _analisadorDeTrinca.Setup(a => a.EhValida(mao)).Returns(true);
            _analisadorDePar.Setup(a => a.EhValida(mao)).Returns(true);

            var ehValida = _analisador.EhValida(mao);

            Assert.True(ehValida);
        }

        [Fact]
        public void Deve_possuir_a_ordem_4()
        {
            const int ordemEsperada = 4;

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