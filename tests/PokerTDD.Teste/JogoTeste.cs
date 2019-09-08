using System.Collections.Generic;
using ExpectedObjects;
using Moq;
using Xunit;

namespace PokerTDD.Teste
{
    public class JogoTeste
    {
        [Fact]
        public void Deve_criar_um_jogo()
        {
            var jogadores = new[]
            {
                JogadorBuilder.Instancia().Construir(),
                JogadorBuilder.Instancia().Construir()
            };
            var analisadorDeJogada = new Mock<AnalisadorDeJogada>();
            var jogoEsperado = new
            {
                Jogadores = jogadores
            };

            var partida = new Jogo(analisadorDeJogada.Object, jogadores);

            jogoEsperado.ToExpectedObject().ShouldMatch(partida);
        }

        [Fact]
        public void Deve_realizar_uma_jogada_e_definir_o_vencedor()
        {
            const string nomeDoVencedorEsperado = "Jogador 1";
            var analisadorDeJogada = new Mock<AnalisadorDeJogada>();
            // analisadorDeJogada.Setup(a => a.ObterGanhador(It.IsAny<Jogador>(), It.IsAny<Jogador>())).Returns("");
            var jogadores = new[]
            {
                JogadorBuilder.Instancia().ComNome(nomeDoVencedorEsperado).Construir(),
                JogadorBuilder.Instancia().ComNome("Jogador 2").Construir()
            };
            var jogo = new Jogo(analisadorDeJogada.Object, jogadores);

            // var vencedor = jogo.RealizarJogada();

            // Assert.Equal(nomeDoVencedorEsperado, vencedor.Nome);
        }

        public class Jogo
        {
            public ICollection<Jogador> Jogadores { get; }
            public AnalisadorDeJogada AnalisadorDeJogada { get; }

            public Jogo(AnalisadorDeJogada analisadorDeJogada, ICollection<Jogador> jogadores)
            {
                AnalisadorDeJogada = analisadorDeJogada;
                Jogadores = jogadores;
            }

            public Jogador RealizarJogada()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
