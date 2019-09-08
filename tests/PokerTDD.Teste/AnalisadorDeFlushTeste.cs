using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeFlushTeste
    {
        [Theory]
        [InlineData("2H", "6H", "AH", "KH", "3H")]
        [InlineData("AC", "7C", "10C", "QC", "JC")]
        [InlineData("10D", "KD", "5D", "JD", "QD")]
        public void Jogador_1_deve_ganhar_com_um_flush(
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
                .ComCartas(new[] { "AD", "QH", "QC", "2S", "9D" }).Construir();
            var analisador = new AnalisadorDeFlush();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador.Nome);
        }

        [Theory]
        [InlineData("QC", "10C", "AC", "KC", "7C")]
        [InlineData("10H", "7H", "2H", "4H", "AH")]
        [InlineData("10D", "KD", "5D", "JD", "QD")]
        public void Jogador_2_deve_ganhar_com_um_flush(
            string carta1DoJogador2, string carta2DoJogador2, string carta3DoJogador2, string carta4DoJogador2, string carta5DoJogador2
        )
        {
            const string ganhadorEsperado = "Jogador 2";
            var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
                .ComCartas(new[] { "KC", "10S", "2C", "2S", "9H" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { 
                    carta1DoJogador2,
                    carta2DoJogador2,
                    carta3DoJogador2,
                    carta4DoJogador2,
                    carta5DoJogador2
                }).Construir();
            var analisador = new AnalisadorDeFlush();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador.Nome);
        }

        [Fact]
        public void Jogador_1_deve_ganhar_no_desempate_com_um_flush()
        {
            const string ganhadorEsperado = "Jogador 1";
            var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { "2H", "3H", "6H", "9H", "AH" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
                .ComCartas(new[] { "QC", "10C", "JC", "KC", "7C" }).Construir();
            var analisador = new AnalisadorDeFlush();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador.Nome);
        }

        [Fact]
        public void Jogador_2_deve_ganhar_no_desempate_com_um_flush()
        {
            const string ganhadorEsperado = "Jogador 2";
            var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
                .ComCartas(new[] { "2H", "3H", "6H", "9H", "JH" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { "QC", "10C", "JC", "KC", "7C" }).Construir();
            var analisador = new AnalisadorDeFlush();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador.Nome);
        }
    }
}