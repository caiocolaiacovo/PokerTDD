using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeFullHouseTeste
    {
        [Theory]
        [InlineData("2D", "6H", "6C", "2S", "2H")]
        [InlineData("AH", "AC", "AS", "QC", "QD")]
        [InlineData("10D", "KH", "10C", "10S", "KD")]
        public void Jogador_1_deve_ganhar_com_um_full_house(
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
                .ComCartas(new[] {"6H", "10S", "QC", "4D", "AH" }).Construir();
            var analisador = new AnalisadorDeFullHouse();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador.Nome);
        }

        [Theory]
        [InlineData("10D", "AH", "10C", "AS", "10H")]
        [InlineData("QH", "QC", "QS", "KC", "KD")]
        [InlineData("2D", "2H", "AC", "AS", "AD")]
        public void Jogador_2_deve_ganhar_com_um_full_house(
            string carta1DoJogador2, string carta2DoJogador2, string carta3DoJogador2, string carta4DoJogador2, string carta5DoJogador2
        )
        {
            const string ganhadorEsperado = "Jogador 2";
            var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
                .ComCartas(new[] { "10D", "QS", "4C", "4D", "7H" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { 
                    carta1DoJogador2, 
                    carta2DoJogador2, 
                    carta3DoJogador2, 
                    carta4DoJogador2, 
                    carta5DoJogador2
                }).Construir();
            var analisador = new AnalisadorDeFullHouse();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador.Nome);
        }

        [Fact]
        public void Jogador_1_deve_ganhar_no_desempate_com_um_full_house_e_uma_trinca_de_maior_valor()
        {
            const string ganhadorEsperado = "Jogador 1";
            var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { "9H", "AS", "AC", "9D", "9C" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
                .ComCartas(new[] { "8H", "8S", "8C", "AD", "AH" }).Construir();
            var analisador = new AnalisadorDeFullHouse();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador.Nome);
        }

        [Fact]
        public void Jogador_2_deve_ganhar_no_desempate_com_um_full_house_e_uma_trinca_de_maior_valor()
        {
            const string ganhadorEsperado = "Jogador 2";
            var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
                .ComCartas(new[] { "6H", "6S", "KC", "KD", "10H" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { "JH", "6D", "6C", "JD", "JC" }).Construir();
            var analisador = new AnalisadorDeFullHouse();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador.Nome);
        }
    }
}