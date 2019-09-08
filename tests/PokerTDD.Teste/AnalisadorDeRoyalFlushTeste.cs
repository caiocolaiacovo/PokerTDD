using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeRoyalFlushTeste
    {
        [Fact]
        public void Deve_ser_um_analisador_de_mao()
        {
            var analisador = new AnalisadorDeRoyalFlush();

            Assert.True(analisador is IAnalisadorDeMao2);
        }

        [Fact]
        public void Jogador_1_deve_ser_o_ganhador_com_um_royal_flush()
        {
            const string ganhadorEsperado = "Jogador 1";
            var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { "10H", "JH", "QH", "KH", "AH" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
                .ComCartas(new[] { "2C", "3S", "8S", "8D", "QD" }).Construir();
            var analisador = new AnalisadorDeRoyalFlush();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador.Nome);
        }

        [Fact]
        public void Jogador_2_deve_ser_o_ganhador_com_um_royal_flush()
        {
            const string ganhadorEsperado = "Jogador 2";
            var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
                .ComCartas(new[] { "2C", "3S", "8S", "8D", "QD" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { "10H", "JH", "QH", "KH", "AH" }).Construir();
            var analisador = new AnalisadorDeRoyalFlush();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador.Nome);
        }

        [Fact]
        public void Nao_deve_retornar_um_jogador_caso_ambos_os_jogadores_possuam_um_royal_flush()
        {
            var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
                .ComCartas(new[] { "10D", "JD", "QD", "KD", "AD" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
                .ComCartas(new[] { "10H", "JH", "QH", "KH", "AH" }).Construir();
            var analisador = new AnalisadorDeRoyalFlush();

            var ganhador = analisador.ObterGanhador(jogador1, jogador2);

            Assert.Null(ganhador);
        }
    }
}