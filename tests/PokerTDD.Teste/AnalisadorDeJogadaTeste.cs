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
        public void Jogador_1_deve_ganhar_no_desempate_com_um_full_house_e_uma_trinca_de_maior_valor()
        {
            const string ganhadorEsperado = "Jogador 1";
            var maoDoJogador1 = new[] { "9H", "AS", "AC", "9D", "9C" };
            var maoDoJogador2 = new[] { "8H", "8S", "8C", "AD", "AH" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Fact]
        public void Jogador_2_deve_ganhar_no_desempate_com_um_full_house_e_uma_trinca_de_maior_valor()
        {
            const string ganhadorEsperado = "Jogador 2";
            var maoDoJogador1 = new[] { "6H", "6S", "KC", "KD", "10H" };
            var maoDoJogador2 = new[] { "JH", "6D", "6C", "JD", "JC" };
            

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Theory]
        [InlineData("2H", "6H", "AH", "KH", "3H")]
        [InlineData("AC", "7C", "10C", "QC", "JC")]
        [InlineData("10D", "KD", "5D", "JD", "QD")]
        public void Jogador_1_deve_ganhar_com_um_flush(
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
            var maoDoJogador2 = new[] { "AD", "QH", "QC", "2S", "9D" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
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
            var maoDoJogador2 = new[] {
                carta1DoJogador2,
                carta2DoJogador2,
                carta3DoJogador2,
                carta4DoJogador2,
                carta5DoJogador2
            };
            var maoDoJogador1 = new[] { "KC", "10S", "2C", "2S", "9H" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Fact]
        public void Jogador_1_deve_ganhar_no_desempate_com_um_flush()
        {
            const string ganhadorEsperado = "Jogador 1";
            var maoDoJogador1 = new[] { "2H", "3H", "6H", "9H", "AH" };
            var maoDoJogador2 = new[] { "QC", "10C", "JC", "KC", "7C" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Fact]
        public void Jogador_2_deve_ganhar_no_desempate_com_um_flush()
        {
            const string ganhadorEsperado = "Jogador 2";
            var maoDoJogador1 = new[] { "2H", "3H", "6H", "9H", "JH" };
            var maoDoJogador2 = new[] { "QC", "10C", "JC", "KC", "7C" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Theory]
        [InlineData("2C", "6D", "5H", "3S", "4C")]
        [InlineData("9C", "8D", "7S", "6H", "10H")]
        [InlineData("10D", "QC", "KD", "JH", "9C")]
        public void Jogador_1_deve_ganhar_com_um_straight(
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
            var maoDoJogador2 = new[] { "KC", "10S", "2C", "2S", "9H" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
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
            var maoDoJogador1 = new[] { "AC", "QS", "8D", "10S", "QH" };
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
        public void Jogador_1_deve_ganhar_no_desempate_com_um_straight()
        {
            const string ganhadorEsperado = "Jogador 1";
            var maoDoJogador1 = new[] { "10C", "9S", "8H", "6H", "7D" };
            var maoDoJogador2 = new[] { "6C", "9S", "8H", "5H", "7D" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Fact]
        public void Jogador_2_deve_ganhar_no_desempate_com_um_straight()
        {
            const string ganhadorEsperado = "Jogador 2";
            var maoDoJogador1 = new[] { "2C", "3S", "4H", "5S", "6D" };
            var maoDoJogador2 = new[] { "7H", "3S", "4H", "5H", "6S" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Theory]
        [InlineData("3S", "2D", "3C", "7H", "3S")]
        [InlineData("KH", "KD", "3C", "7H", "KS")]
        [InlineData("AS", "2D", "3C", "AD", "AC")]
        public void Jogador_1_deve_ganhar_com_uma_trinca(
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
            var maoDoJogador2 = new[] { "2D", "6S", "AS", "QH", "QK" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Theory]
        [InlineData("10S", "10D", "10C", "7H", "3S")]
        [InlineData("AH", "AD", "AC", "QD", "JS")]
        [InlineData("KS", "KD", "KC", "AD", "2C")]
        public void Jogador_2_deve_ganhar_com_uma_trinca(
            string carta1DoJogador2, string carta2DoJogador2, string carta3DoJogador2, string carta4DoJogador2, string carta5DoJogador2
        )
        {
            const string ganhadorEsperado = "Jogador 2";
            var maoDoJogador1 = new[] { "KS", "3H", "AS", "10C", "9D" };
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
        public void Jogador_1_deve_ganhar_no_desempate_com_uma_trinca()
        {
            const string ganhadorEsperado = "Jogador 1";
            var maoDoJogador1 = new[] { "2D", "3S", "5H", "5C", "5D" };
            var maoDoJogador2 = new[] { "2C", "3H", "4D", "4H", "4C" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Fact]
        public void Jogador_2_deve_ganhar_no_desempate_com_uma_trinca()
        {
            const string ganhadorEsperado = "Jogador 2";
            var maoDoJogador1 = new[] { "QS", "KC", "2S", "2C", "2D" };
            var maoDoJogador2 = new[] { "4S", "5C", "AS", "AC", "AD" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Theory]
        [InlineData("2S", "2D", "10C", "10H", "3S")]
        [InlineData("AH", "AD", "KC", "QD", "KS")]
        [InlineData("7S", "7D", "KC", "AD", "AC")]
        public void Jogador_1_deve_ganhar_com_dois_pares(
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
            var maoDoJogador2 = new[] { "7C", "QH", "AS", "10C", "10S" };
    
            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Theory]
        [InlineData("QD", "QS", "AC", "10H", "AS")]
        [InlineData("QS", "KD", "KC", "QD", "2S")]
        [InlineData("10S", "AS", "10C", "AD", "KC")]
        public void Jogador_2_deve_ganhar_com_dois_pares(
            string carta1DoJogador2, string carta2DoJogador2, string carta3DoJogador2, string carta4DoJogador2, string carta5DoJogador2
        )
        {
            const string ganhadorEsperado = "Jogador 2";
            var maoDoJogador1 = new[] { "AS", "10H", "5C", "10D", "KS" };
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
        public void Jogador_1_deve_ganhar_no_desempate_com_dois_pares()
        {
            const string ganhadorEsperado = "Jogador 1";
            var maoDoJogador1 = new[] { "3H", "2C", "2S", "3S", "KD" };
            var maoDoJogador2 = new[] { "4S", "QC", "4H", "3C", "3D" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Fact]
        public void Jogador_2_deve_ganhar_no_desempate_com_dois_pares()
        {
            const string ganhadorEsperado = "Jogador 2";
            var maoDoJogador1 = new[] { "7C", "7D", "10S", "10H", "KD" };
            var maoDoJogador2 = new[] { "7S", "7H", "10C", "10D", "AD" };
            

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Theory]
        [InlineData("QS", "2D", "QC", "10H", "3S")]
        [InlineData("AH", "AD", "KC", "QD", "JS")]
        [InlineData("7S", "3D", "8C", "KD", "KC")]
        public void Jogador_1_deve_ganhar_com_um_par(
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
            var maoDoJogador2 = new[] { "2S", "10H", "AS", "JD", "QD" };
    
            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Theory]
        [InlineData("4D", "KD", "QC", "2H", "2S")]
        [InlineData("6H", "AD", "KC", "QD", "QS")]
        [InlineData("7S", "3D", "8C", "KD", "KC")]
        public void Jogador_2_deve_ganhar_com_um_par(
            string carta1DoJogador2, string carta2DoJogador2, string carta3DoJogador2, string carta4DoJogador2, string carta5DoJogador2
        )
        {
            const string ganhadorEsperado = "Jogador 2";
            var maoDoJogador1 = new[] { "AS", "QH", "6S", "10D", "JD" };
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
        public void Jogador_1_deve_ganhar_no_desempate_com_um_par()
        {
            const string ganhadorEsperado = "Jogador 1";
            var maoDoJogador1 = new[] { "3H", "2C", "10D", "10S", "KD" };
            var maoDoJogador2 = new[] { "10C", "10H", "4H", "3C", "2D" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Fact]
        public void Jogador_2_deve_ganhar_no_desempate_com_um_par()
        {
            const string ganhadorEsperado = "Jogador 2";
            var maoDoJogador1 = new[] { "QH", "2C", "QD", "5S", "KD" };
            var maoDoJogador2 = new[] { "10C", "AH", "QS", "QC", "2D" };

            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Theory]
        [InlineData("7C", "2H", "JC", "10H", "AS")]
        [InlineData("2H", "6D", "KC", "7D", "JS")]
        [InlineData("2C", "3D", "8C", "QD", "5D")]
        public void Jogador_1_deve_ganhar_com_a_carta_mais_alta(
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
            var maoDoJogador2 = new[] { "3D", "9H", "2S", "JD", "4D" };
    
            var ganhador = AnalisadorDeJogada.ObterGanhador(maoDoJogador1, maoDoJogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Theory]
        [InlineData("7C", "2H", "KC", "10H", "6S")]
        [InlineData("2H", "6D", "4C", "7D", "QS")]
        [InlineData("JC", "3D", "8C", "6D", "5D")]
        public void Jogador_2_deve_ganhar_com_a_carta_mais_alta(
            string carta1DoJogador2, string carta2DoJogador2, string carta3DoJogador2, string carta4DoJogador2, string carta5DoJogador2
        )
        {
            const string ganhadorEsperado = "Jogador 2";
            var maoDoJogador1 = new[] { "6D", "10H", "2S", "7D", "4D" };
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

                    return "Jogador 2";
                }

                var jogador1PossuiUmFlush = ValidarFlush(maoDoJogador1);
                var jogador2PossuiUmFlush = ValidarFlush(maoDoJogador2);

                if (jogador1PossuiUmFlush && !jogador2PossuiUmFlush)
                    return "Jogador 1";

                if (jogador2PossuiUmFlush && !jogador1PossuiUmFlush)
                    return "Jogador 2";

                if (jogador1PossuiUmFlush && jogador2PossuiUmFlush)
                {
                    var maiorCartaDoJogador1 = ObterMaiorCartaDaMao(maoDoJogador1, "Flush");
                    var maiorCartaDoJogador2 = ObterMaiorCartaDaMao(maoDoJogador2, "Flush");

                    if (maiorCartaDoJogador1 > maiorCartaDoJogador2)
                        return "Jogador 1";

                    return "Jogador 2";
                }

                var jogador1PossuiUmStraight = ValidarStraight(maoDoJogador1);
                var jogador2PossuiUmStraight = ValidarStraight(maoDoJogador2);

                if (jogador1PossuiUmStraight && !jogador2PossuiUmStraight)
                    return "Jogador 1";

                if (jogador2PossuiUmStraight && !jogador1PossuiUmStraight)
                    return "Jogador 2";

                if (jogador1PossuiUmStraight && jogador2PossuiUmStraight)
                {
                    var maiorCartaDoJogador1 = ObterMaiorCartaDaMao(maoDoJogador1, "Straight");
                    var maiorCartaDoJogador2 = ObterMaiorCartaDaMao(maoDoJogador2, "Straight");

                    if (maiorCartaDoJogador1 > maiorCartaDoJogador2)
                        return "Jogador 1";

                    return "Jogador 2";
                }

                var jogador1PossuiUmaTrinca = ValidarTrinca(maoDoJogador1);
                var jogador2PossuiUmaTrinca = ValidarTrinca(maoDoJogador2);

                if (jogador1PossuiUmaTrinca && !jogador2PossuiUmaTrinca)
                    return "Jogador 1";

                if (jogador2PossuiUmaTrinca && !jogador1PossuiUmaTrinca)
                    return "Jogador 2";

                if (jogador1PossuiUmaTrinca && jogador2PossuiUmaTrinca)
                {
                    var maiorCartaDoJogador1 = ObterMaiorCartaDaMao(maoDoJogador1, "Trinca");
                    var maiorCartaDoJogador2 = ObterMaiorCartaDaMao(maoDoJogador2, "Trinca");

                    if (maiorCartaDoJogador1 > maiorCartaDoJogador2)
                        return "Jogador 1";

                    return "Jogador 2";
                }

                var jogador1PossuiDoisPares = ValidarDoisPares(maoDoJogador1);
                var jogador2PossuiDoisPares = ValidarDoisPares(maoDoJogador2);

                if (jogador1PossuiDoisPares && !jogador2PossuiDoisPares)
                    return "Jogador 1";

                if (jogador2PossuiDoisPares && !jogador1PossuiDoisPares)
                    return "Jogador 2";

                if (jogador1PossuiDoisPares && jogador2PossuiDoisPares)
                {
                    var maiorCartaDoJogador1 = ObterMaiorCartaDaMao(maoDoJogador1, "DoisPares");
                    var maiorCartaDoJogador2 = ObterMaiorCartaDaMao(maoDoJogador2, "DoisPares");

                    if (maiorCartaDoJogador1 > maiorCartaDoJogador2)
                        return "Jogador 1";

                    return "Jogador 2";
                }
                
                var jogador1PossuiUmPar = ValidarUmPar(maoDoJogador1);
                var jogador2PossuiUmPar = ValidarUmPar(maoDoJogador2);

                if (jogador1PossuiUmPar && !jogador2PossuiUmPar)
                    return "Jogador 1";

                if (jogador2PossuiUmPar && !jogador1PossuiUmPar)
                    return "Jogador 2";

                if (jogador1PossuiUmPar && jogador2PossuiUmPar)
                {
                    var maiorCartaDoJogador1 = ObterMaiorCartaDaMao(maoDoJogador1, "UmPar");
                    var maiorCartaDoJogador2 = ObterMaiorCartaDaMao(maoDoJogador2, "UmPar");

                    if (maiorCartaDoJogador1 > maiorCartaDoJogador2)
                        return "Jogador 1";

                    return "Jogador 2";
                }

                var cartaAltaDoJogador1 = ObterMaiorCartaDaMao(maoDoJogador1, "CartaAlta");
                var cartaAltaDoJogador2 = ObterMaiorCartaDaMao(maoDoJogador2, "CartaAlta");

                if (cartaAltaDoJogador1 > cartaAltaDoJogador2)
                    return "Jogador 1";

                return "Jogador 2";
            }

            private static bool ValidarUmPar(string[] maoDoJogador)
            {
                var cartasSemNaipe = maoDoJogador.Select(ObterCartaSemNaipe);

                var possuiUmPar = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 2).Count() == 1;
                var naoPossuiOutrasCartasRepetidas = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 1).Count() == 3;

                return possuiUmPar && naoPossuiOutrasCartasRepetidas;
            }

            private static bool ValidarDoisPares(string[] maoDoJogador)
            {
                var cartasSemNaipe = maoDoJogador.Select(ObterCartaSemNaipe);

                var possuiDoisPares = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 2).Count() == 2;

                return possuiDoisPares;
            }

            private static bool ValidarTrinca(string[] maoDoJogador)
            {
                var cartasSemNaipe = maoDoJogador.Select(ObterCartaSemNaipe);

                var possuiUmaTrinca = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 3).Any();
                var possuiUmPar = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 2).Any();

                return possuiUmaTrinca && !possuiUmPar;
            }

            private static bool ValidarStraight(string[] maoDoJogador)
            {
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

            private static bool ValidarFlush(string[] maoDoJogador)
            {
                var cartasSaoDoMesmoNaipe = maoDoJogador.GroupBy(m => m.Last()).Count() == 1;

                return cartasSaoDoMesmoNaipe;
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
                if (mao.Equals("StraightFlush") || mao.Equals("Flush") || 
                mao.Equals("Straight") || mao.Equals("DoisPares") || mao.Equals("UmPar") || mao.Equals("CartaAlta")) 
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
                    var cartasSemNaipe = maoDoJogador.Select(ObterCartaSemNaipe);

                    var trinca = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 3).First();

                    return trinca.First();
                }

                if (mao.Equals("Trinca"))
                {
                    var cartasSemNaipe = maoDoJogador.Select(ObterCartaSemNaipe);

                    var trinca = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 3).First();

                    return trinca.First();
                }

                return 0;
            }

            private static bool ValidarStraightFlush(string[] maoDoJogador)
            {
                var cartasSaoDoMesmoNaipe = maoDoJogador.GroupBy(m => m.Last()).Count() == 1;

                if (!cartasSaoDoMesmoNaipe)
                    return false;

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
