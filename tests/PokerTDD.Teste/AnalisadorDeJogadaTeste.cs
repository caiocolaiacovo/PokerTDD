using System;
using System.Linq;
using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeJogadaTeste
    {
        [Fact]
        public void Jogador_1_deve_ser_o_ganhador_com_um_royal_flush()
        {
            const string ganhadorEsperado = "Jogador 1";
            var maoDoJogador1 = new[] { "10H", "JH", "QH", "KH", "AH" };
            var maoDoJogador2 = new[] { "2C", "3S", "8S", "8D", "QD" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Fact]
        public void Jogador_2_deve_ser_o_ganhador_com_um_royal_flush()
        {
            const string ganhadorEsperado = "Jogador 2";
            var maoDoJogador1 = new[] { "2C", "3S", "8S", "8D", "QD" };
            var maoDoJogador2 = new[] { "10H", "JH", "QH", "KH", "AH" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Fact]
        public void Deve_resultar_em_empate_caso_ambos_os_jogadores_possuam_um_royal_flush()
        {
            const string ganhadorEsperado = "Empate";
            var maoDoJogador1 = new[] { "10D", "JD", "QD", "KD", "AD" };
            var maoDoJogador2 = new[] { "10H", "JH", "QH", "KH", "AH" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
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
            var maoDoJogador1 = new[] { 
                carta1DoJogador1,
                carta2DoJogador1,
                carta3DoJogador1,
                carta4DoJogador1,
                carta5DoJogador1 
            };
            var maoDoJogador2 = new[] { "2C", "3S", "8S", "8D", "QD" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
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
            var maoDoJogador1 = new[] { "2C", "3S", "8S", "8D", "JD" };
            var maoDoJogador2 = new[] { 
                carta1DoJogador2,
                carta2DoJogador2,
                carta3DoJogador2,
                carta4DoJogador2,
                carta5DoJogador2 
            };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        public class AnalisadorDeJogada
        {
            public static string ObterGanhador(string[] maoDoJogador1, string[] maoDoJogador2)
            {
                var jogador1PossuiUmRoyalFlush = ValidarRoyalFlush(maoDoJogador1);
                var jogador2PossuiUmRoyalFlush = ValidarRoyalFlush(maoDoJogador2);

                if (jogador1PossuiUmRoyalFlush && !jogador2PossuiUmRoyalFlush)
                    return "Jogador 1";

                if (jogador2PossuiUmRoyalFlush && !jogador1PossuiUmRoyalFlush)
                    return "Jogador 2";

                if (jogador1PossuiUmRoyalFlush && jogador2PossuiUmRoyalFlush)
                    return "Empate";

                var jogador1PossuiUmStraightFlush = ValidarStraightFlush(maoDoJogador1);
                var jogador2PossuiUmStraightFlush = ValidarStraightFlush(maoDoJogador2);

                if (jogador1PossuiUmStraightFlush && !jogador2PossuiUmStraightFlush)
                    return "Jogador 1";

                if (jogador2PossuiUmStraightFlush && !jogador1PossuiUmStraightFlush)
                    return "Jogador 2";

                return "Empate";
            }

            private static bool ValidarStraightFlush(string[] maoDoJogador)
            {
                var cartasSaoDoMesmoNaipe = maoDoJogador.GroupBy(m => m.Last()).Count() == 1;

                var cartasOrdenadas = maoDoJogador.Select(c => {
                    var cartaSemNaipe = c.Remove(c.Length - 1, 1);

                    return ObterValorDaCarta(cartaSemNaipe);
                }).OrderBy(c => c).ToList();

                var valor = cartasOrdenadas.First();

                foreach (var carta in cartasOrdenadas)
                {
                    if (valor != carta)
                        return false;
                    
                    valor++;
                }

                return true;
            }

            private static int ObterValorDaCarta(string cartaSemNaipe)
            {
                if (cartaSemNaipe.Equals("J"))
                    return 11;
                
                if (cartaSemNaipe.Equals("Q"))
                    return 12;

                if (cartaSemNaipe.Equals("K"))
                    return 13;
                
                if (cartaSemNaipe.Equals("A"))
                    return 14;

                return Convert.ToInt32(cartaSemNaipe);
            }

            private static bool ValidarRoyalFlush(string[] maoDoJogador)
            {
                var cartasSaoDoMesmoNaipe = maoDoJogador.GroupBy(m => m.Last()).Count() == 1;

                return cartasSaoDoMesmoNaipe && 
                    maoDoJogador.Any(m => m.Contains("10")) &&
                    maoDoJogador.Any(m => m.Contains("J")) &&
                    maoDoJogador.Any(m => m.Contains("Q")) &&
                    maoDoJogador.Any(m => m.Contains("K")) &&
                    maoDoJogador.Any(m => m.Contains("A"));
            }
        }
    }
}
