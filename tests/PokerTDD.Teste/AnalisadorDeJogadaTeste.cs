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

        [Fact]
        public void Jogador_1_deve_ganhar_no_desempate_com_um_straight_flush()
        {
            const string ganhadorEsperado = "Jogador 1";
            var maoDoJogador1 = new[] { "KD", "9D", "JD", "10D", "QD" };
            var maoDoJogador2 = new[] { "5H", "2H", "6H", "3H", "4H" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Fact]
        public void Jogador_2_deve_ganhar_no_desempate_com_um_straight_flush()
        {
            const string ganhadorEsperado = "Jogador 2";
            var maoDoJogador1 = new[] { "2D", "6D", "4D", "3D", "5D" };
            var maoDoJogador2 = new[] { "9H", "JH", "10H", "8H", "7H" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Theory]
        [InlineData("2D", "2H", "2C", "2S", "5D")]
        [InlineData("QD", "QH", "QC", "QS", "AD")]
        [InlineData("10D", "10H", "10C", "2S", "10S")]
        public void Jogador_1_deve_ganhar_com_uma_quadra(
            string carta1DoJogador1, string carta2DoJogador1, string carta3DoJogador1, string carta4DoJogador1, string carta5DoJogador1
        )
        {
            const string ganhadorEsperado = "Jogador 1";
            var maoDoJogador1 = new[] {
                carta1DoJogador1, 
                carta2DoJogador1, 
                carta3DoJogador1, 
                carta4DoJogador1, 
                carta5DoJogador1
            };
            var maoDoJogador2 = new[] { "9H", "3S", "10C", "4D", "QH" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
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
            var maoDoJogador1 = new[] { "KH", "2S", "7C", "10D", "QH" };
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

        [Fact]
        public void Jogador_1_deve_ganhar_no_desempate_com_uma_quadra()
        {
            const string ganhadorEsperado = "Jogador 1";
            var maoDoJogador1 = new[] { "AH", "AS", "AC", "AD", "QH" };
            var maoDoJogador2 = new[] { "10H", "10S", "10C", "10D", "2H" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Fact]
        public void Jogador_2_deve_ganhar_no_desempate_com_uma_quadra()
        {
            const string ganhadorEsperado = "Jogador 2";
            var maoDoJogador1 = new[] { "6H", "6S", "6C", "6D", "KH" };
            var maoDoJogador2 = new[] { "10H", "10S", "10C", "10D", "JH" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Theory]
        [InlineData("2D", "6H", "6C", "2S", "2H")]
        [InlineData("AH", "AC", "AS", "QC", "QD")]
        [InlineData("10D", "KH", "10C", "10S", "KD")]
        public void Jogador_1_deve_ganhar_com_um_full_house(
            string carta1DoJogador1, string carta2DoJogador1, string carta3DoJogador1, string carta4DoJogador1, string carta5DoJogador1
        )
        {
            const string ganhadorEsperado = "Jogador 1";
            var maoDoJogador1 = new[] {
                carta1DoJogador1, 
                carta2DoJogador1, 
                carta3DoJogador1, 
                carta4DoJogador1, 
                carta5DoJogador1
            };
            var maoDoJogador2 = new[] { "6H", "10S", "QC", "4D", "AH" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
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
            var maoDoJogador1 = new[] { "10D", "QS", "4C", "4D", "7H" };
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

        [Fact]
        public void Jogador_1_deve_ganhar_no_desempate_com_um_full_house()
        {
            const string ganhadorEsperado = "Jogador 1";
            var maoDoJogador1 = new[] { "6H", "6S", "6C", "KD", "KH" };
            var maoDoJogador2 = new[] { "2H", "AS", "AC", "2D", "2C" };

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

                if (jogador1PossuiUmStraightFlush && jogador2PossuiUmStraightFlush)
                {
                    var maiorCartaDoJogador1 = ObterMaiorCartaDaMao(maoDoJogador1, "StraightFlush");
                    var maiorCartaDoJogador2 = ObterMaiorCartaDaMao(maoDoJogador2, "StraightFlush");

                    if (maiorCartaDoJogador1 > maiorCartaDoJogador2)
                        return "Jogador 1";
                    
                    return "Jogador 2";
                }

                var jogador1PossuiUmaQuadra = ValidarQuadra(maoDoJogador1);
                var jogador2PossuiUmaQuadra = ValidarQuadra(maoDoJogador2);

                if (jogador1PossuiUmaQuadra && !jogador2PossuiUmaQuadra)
                    return "Jogador 1";

                if (jogador2PossuiUmaQuadra && !jogador1PossuiUmaQuadra)
                    return "Jogador 2";

                if (jogador1PossuiUmaQuadra && jogador2PossuiUmaQuadra)
                {
                    var maiorCartaDoJogador1 = ObterMaiorCartaDaMao(maoDoJogador1, "Quadra");
                    var maiorCartaDoJogador2 = ObterMaiorCartaDaMao(maoDoJogador2, "Quadra");

                    if (maiorCartaDoJogador1 > maiorCartaDoJogador2)
                        return "Jogador 1";
                    
                    return "Jogador 2";
                }

                var jogador1PossuiUmFullHouse = ValidarFullHouse(maoDoJogador1);
                var jogador2PossuiUmFullHouse = ValidarFullHouse(maoDoJogador2);

                if (jogador1PossuiUmFullHouse && !jogador2PossuiUmFullHouse)
                    return "Jogador 1";

                if (jogador2PossuiUmFullHouse && !jogador1PossuiUmFullHouse)
                    return "Jogador 2";

                if (jogador1PossuiUmFullHouse && jogador2PossuiUmFullHouse)
                {
                    var maiorCartaDoJogador1 = ObterMaiorCartaDaMao(maoDoJogador1, "FullHouse");
                    var maiorCartaDoJogador2 = ObterMaiorCartaDaMao(maoDoJogador2, "FullHouse");

                    if (maiorCartaDoJogador1 > maiorCartaDoJogador2)
                        return "Jogador 1";
                }

                return "Nenhum";
            }

            private static bool ValidarFullHouse(string[] maoDoJogador)
            {
                var cartasSemNaipe = maoDoJogador.Select(ObterCartaSemNaipe);

                var cartasAgrupadasPorValor = cartasSemNaipe.GroupBy(c => c);

                var possuiUmaTrinca = cartasAgrupadasPorValor.Where(g => g.Count() == 3).Any();
                var possuiUmPar = cartasAgrupadasPorValor.Where(g => g.Count() == 2).Any();

                return possuiUmaTrinca && possuiUmPar;
            }

            private static bool ValidarQuadra(string[] maoDoJogador)
            {
                var cartasSemNaipe = maoDoJogador.Select(ObterCartaSemNaipe);

                var possuiQuatroCartasIguais = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 4).Any();

                return possuiQuatroCartasIguais;
            }

            private static int ObterMaiorCartaDaMao(string[] maoDoJogador, string mao)
            {
                if (mao.Equals("StraightFlush")) 
                {
                    var valorDaMaiorCarta = 0;

                    foreach (var carta in maoDoJogador)
                    {
                        var valorDaCarta = ObterCartaSemNaipe(carta);

                        if (valorDaCarta > valorDaMaiorCarta)
                            valorDaMaiorCarta = valorDaCarta;
                    }

                    return valorDaMaiorCarta;
                }

                if (mao.Equals("Quadra"))
                {
                    var cartasSemNaipe = maoDoJogador.Select(ObterCartaSemNaipe);

                    var quadra = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 4).First();

                    return quadra.First();
                }

                if (mao.Equals("FullHouse"))
                {
                    //
                }

                return 0;
            }

            private static bool ValidarStraightFlush(string[] maoDoJogador)
            {
                var cartasSaoDoMesmoNaipe = maoDoJogador.GroupBy(m => m.Last()).Count() == 1;

                var cartasOrdenadas = maoDoJogador.Select(ObterCartaSemNaipe).OrderBy(c => c).ToList();

                var valor = cartasOrdenadas.First();

                foreach (var carta in cartasOrdenadas)
                {
                    if (valor != carta)
                        return false;
                    
                    valor++;
                }

                return true;
            }

            private static int ObterCartaSemNaipe(string carta)
            {
                var cartaSemNaipe = carta.Remove(carta.Length - 1, 1);

                return ObterValorDaCarta(cartaSemNaipe);
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
