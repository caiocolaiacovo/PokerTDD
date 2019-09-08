using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeStraightFlushTeste
    {
        [Fact]
        public void Deve_ser_um_validador_de_mao()
        {
            var analisador = new AnalisadorDeStraightFlush();

            Assert.True(analisador is IAnalisadorDeMao2);
        }

        [Theory]
        [InlineData("5H", "2H", "6H", "3H", "4H")]
        [InlineData("KD", "9D", "JD", "10D", "QD")]
        [InlineData("5C", "6C", "7C", "8C", "9C")]
        [InlineData("2S", "5S", "6S", "3S", "4S")]
        public void Jogador_1_deve_ser_o_ganhador_com_um_straight_flush(
            string carta1DoJogador1, string carta2DoJogador1, string carta3DoJogador1, string carta4DoJogador1, string carta5DoJogador1)
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
                .ComCartas(new[] { "2C", "3S", "8S", "8D", "QD" }).Construir();
            var analisador = new AnalisadorDeStraightFlush();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador.Nome);
        }

        [Theory]
        [InlineData("5H", "2H", "6H", "3H", "4H")]
        [InlineData("KD", "9D", "JD", "10D", "QD")]
        [InlineData("5C", "6C", "7C", "8C", "9C")]
        [InlineData("2S", "5S", "6S", "3S", "4S")]
        public void Jogador_2_deve_ser_o_ganhador_com_um_straight_flush(
            string carta1DoJogador2, string carta2DoJogador2, string carta3DoJogador2, string carta4DoJogador2, string carta5DoJogador2)
        {
            const string ganhadorEsperado = "Jogador 2";
            var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
                .ComCartas(new[] { "2C", "3S", "8S", "8D", "JD" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { 
                    carta1DoJogador2,
                    carta2DoJogador2,
                    carta3DoJogador2,
                    carta4DoJogador2,
                    carta5DoJogador2 
                 }).Construir();
            var analisador = new AnalisadorDeStraightFlush();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador.Nome);
        }

        [Fact]
        public void Jogador_1_deve_ganhar_no_desempate_com_um_straight_flush()
        {
            const string ganhadorEsperado = "Jogador 1";
            var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { "KD", "9D", "JD", "10D", "QD" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
                .ComCartas(new[] { "5H", "2H", "6H", "3H", "4H" }).Construir();
            var analisador = new AnalisadorDeStraightFlush();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador.Nome);
        }

        [Fact]
        public void Jogador_2_deve_ganhar_no_desempate_com_um_straight_flush()
        {
            const string ganhadorEsperado = "Jogador 2";
            var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
                .ComCartas(new[] { "2D", "6D", "4D", "3D", "5D" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { "9H", "JH", "10H", "8H", "7H" }).Construir();
            var analisador = new AnalisadorDeStraightFlush();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador.Nome);
        }
    }
}