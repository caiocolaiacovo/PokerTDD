using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeStraightTeste
    {
        [Theory]
        [InlineData("2C", "6D", "5H", "3S", "4C")]
        [InlineData("9C", "8D", "7S", "6H", "10H")]
        [InlineData("10D", "QC", "KD", "JH", "9C")]
        public void Jogador_1_deve_ganhar_com_um_straight(
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
                .ComCartas(new[] { "KC", "10S", "2C", "2S", "9H" }).Construir();
            var analisador = new AnalisadorDeStraight();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador.Nome);
        }

        [Theory]
        [InlineData("7H", "JC", "8C", "9D", "10S")]
        [InlineData("3S", "2D", "6C", "4H", "5S")]
        [InlineData("5D", "6C", "7D", "8H", "9C")]
        public void Jogador_2_deve_ganhar_com_um_straight(
            string carta1DoJogador2, string carta2DoJogador2, string carta3DoJogador2, string carta4DoJogador2, string carta5DoJogador2
        )
        {
            const string ganhadorEsperado = "Jogador 2";
            var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
                .ComCartas(new[] { "AC", "QS", "8D", "10S", "QH" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { 
                    carta1DoJogador2,
                    carta2DoJogador2,
                    carta3DoJogador2,
                    carta4DoJogador2,
                    carta5DoJogador2
                }).Construir();
            var analisador = new AnalisadorDeStraight();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador.Nome);
        }

        [Fact]
        public void Jogador_1_deve_ganhar_no_desempate_com_um_straight()
        {
            const string ganhadorEsperado = "Jogador 1";
            var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { "10C", "9S", "8H", "6H", "7D" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 1")
                .ComCartas(new[] { "6C", "9S", "8H", "5H", "7D" }).Construir();
            var analisador = new AnalisadorDeStraight();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador.Nome);
        }

        [Fact]
        public void Jogador_2_deve_ganhar_no_desempate_com_um_straight()
        {
            const string ganhadorEsperado = "Jogador 2";
            var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
                .ComCartas(new[] { "2C", "3S", "4H", "5S", "6D" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { "7H", "3S", "4H", "5H", "6S" }).Construir();
            var analisador = new AnalisadorDeStraight();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador.Nome);
        }
    }
}