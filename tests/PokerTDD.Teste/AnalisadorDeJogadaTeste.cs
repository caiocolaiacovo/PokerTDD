using System.Collections.Generic;
using System.Linq;
using ExpectedObjects;
using Moq;
using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeJogadaTeste
    {
        public Mock<IAnalisadorDeMao> _analisadorUm;
        public Mock<IAnalisadorDeMao> _analisadorDois;
        public Mock<IAnalisadorDeMao> _analisadorTres;
        public IEnumerable<IAnalisadorDeMao> _listaDeAnalisadores;
        public AnalisadorDeJogada _analisadorDeJogada;

        public AnalisadorDeJogadaTeste()
        {
            _analisadorUm = new Mock<IAnalisadorDeMao>();
            _analisadorDois = new Mock<IAnalisadorDeMao>();
            _analisadorTres = new Mock<IAnalisadorDeMao>();

            _analisadorUm.SetupGet(a => a.Ordem).Returns(1);
            _analisadorDois.SetupGet(a => a.Ordem).Returns(3);
            _analisadorTres.SetupGet(a => a.Ordem).Returns(2);

            _listaDeAnalisadores = new[] {
                _analisadorUm.Object,
                _analisadorDois.Object,
                _analisadorTres.Object,
            };

            _analisadorDeJogada = new AnalisadorDeJogada(_listaDeAnalisadores);
        }

        [Fact]
        public void Deve_criar_um_analisador_de_jogada_com_a_ordem_correta_dos_analisadores()
        {
            var analisadorDeJogadaEsperado = new {
                AnalisadoresDeMao = _listaDeAnalisadores.OrderBy(a => a.Ordem)
            };

            analisadorDeJogadaEsperado.ToExpectedObject().ShouldMatch(_analisadorDeJogada);
        }

        [Fact]
        public void Deve_percorrer_todos_os_analisadores()
        {
            var maoDoJogador1 = new[] {"2C", "KD", "10H", "5C", "5S"};
            var maoDoJogador2 = new[] {"KC", "AS", "4D", "6H", "JS"};
            
            _analisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            _analisadorUm.Verify(a => a.EhValida(It.Is<IEnumerable<string>>(e => 
                e.Equals(maoDoJogador1) || e.Equals(maoDoJogador2))), Times.AtLeast(2));
            _analisadorDois.Verify(a => a.EhValida(It.Is<IEnumerable<string>>(e => 
                e.Equals(maoDoJogador1) || e.Equals(maoDoJogador2))), Times.AtLeast(2));
            _analisadorTres.Verify(a => a.EhValida(It.Is<IEnumerable<string>>(e => 
                e.Equals(maoDoJogador1) || e.Equals(maoDoJogador2))), Times.AtLeast(2));
        }

        [Fact]
        public void Deve_informar_que_nao_houve_nenhum_ganhador()
        {
            const string ganhadorEsperado = "Nenhum";

            var ganhador = _analisadorDeJogada.ObterGanhador(new string[] {}, new string[] {});

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Theory]
        [InlineData("Jogador 1", true, false)]
        [InlineData("Jogador 2", false, true)]
        public void Deve_obter_o_jogador_1_como_ganhador(string ganhadorEsperado, bool maoDoJogador1EhValida, bool maoDoJogador2EhValida)
        {
            _analisadorUm.SetupSequence(a => a.EhValida(It.IsAny<IEnumerable<string>>()))
                .Returns(maoDoJogador1EhValida)
                .Returns(maoDoJogador2EhValida);

            var ganhador = _analisadorDeJogada.ObterGanhador(new string[] {}, new string[] {});

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Theory]
        [InlineData("Jogador 1", 2, 1)]
        [InlineData("Jogador 2", 1, 2)]
        public void Deve_o_jogador_1_ganhar_no_desempate(string ganhadorEsperado, int maiorCartaDoJogador1, int maiorCartaDoJogador2)
        {
            _analisadorUm.Setup(a => a.EhValida(It.IsAny<IEnumerable<string>>()))
                .Returns(true);
            _analisadorUm.SetupSequence(a => a.ObterMaiorCartaDaMao(It.IsAny<IEnumerable<string>>()))
                .Returns(maiorCartaDoJogador1)
                .Returns(maiorCartaDoJogador2);
            
            var ganhador = _analisadorDeJogada.ObterGanhador(new string[] {}, new string[] {});

            Assert.Equal(ganhadorEsperado, ganhador);
        }
    }
}