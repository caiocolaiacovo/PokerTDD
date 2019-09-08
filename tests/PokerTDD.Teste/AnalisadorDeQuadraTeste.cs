using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeQuadraTeste
    {
        [Theory]
        [InlineData("2D", "2H", "2C", "2S", "5D")]
        [InlineData("QD", "QH", "QC", "QS", "AD")]
        [InlineData("10D", "10H", "10C", "2S", "10S")]
        public void Jogador_1_deve_ganhar_com_uma_quadra(
            string carta1DoJogador1, string carta2DoJogador1, string carta3DoJogador1, string carta4DoJogador1, string carta5DoJogador1
        )
        {
            const string ganhadorEsperado = "Jogador 1";
            var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { 
                    carta1DoJogador1, 
                    carta2DoJogador1, 
                    carta3DoJogador1, 
                    carta4DoJogador1, 
                    carta5DoJogador1
                }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
                .ComCartas(new[] { "9H", "3S", "10C", "4D", "QH" }).Construir();
            var analisador = new AnalisadorDeQuadra();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador.Nome);
        }

        [Theory]
        [InlineData("2D", "6H", "6C", "6S", "6D")]
        [InlineData("JD", "JH", "JC", "JS", "5D")]
        [InlineData("AD", "AH", "AC", "AS", "QS")]
        public void Jogador_2_deve_ganhar_com_uma_quadra(
            string carta1DoJogador2, string carta2DoJogador2, string carta3DoJogador2, string carta4DoJogador2, string carta5DoJogador2
        )
        {
            const string ganhadorEsperado = "Jogador 2";
            var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
                .ComCartas(new[] { "KH", "2S", "7C", "10D", "QH" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { 
                    carta1DoJogador2, 
                    carta2DoJogador2, 
                    carta3DoJogador2, 
                    carta4DoJogador2, 
                    carta5DoJogador2
                }).Construir();
            var analisador = new AnalisadorDeQuadra();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador.Nome);
        }

        [Fact]
        public void Jogador_1_deve_ganhar_no_desempate_com_uma_quadra()
        {
            const string ganhadorEsperado = "Jogador 1";
            var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { "AH", "AS", "AC", "AD", "QH" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
                .ComCartas(new[] { "10H", "10S", "10C", "10D", "2H" }).Construir();
            var analisador = new AnalisadorDeQuadra();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador.Nome);
        }

        [Fact]
        public void Jogador_2_deve_ganhar_no_desempate_com_uma_quadra()
        {
            const string ganhadorEsperado = "Jogador 2";
            var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
                .ComCartas(new[] { "6H", "6S", "6C", "6D", "KH" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { "10H", "10S", "10C", "10D", "JH" }).Construir();
            var analisador = new AnalisadorDeQuadra();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador.Nome);
        }
    }
}