using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeJogadaTeste
    {
        // [Fact]
        // public void Jogador_1_deve_ser_o_ganhador_com_um_royal_flush()
        // {
        //     const string ganhadorEsperado = "Jogador 1";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
        //         .ComCartas(new[] { "10H", "JH", "QH", "KH", "AH" }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
        //         .ComCartas(new[] { "2C", "3S", "8S", "8D", "QD" }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }

        // [Fact]
        // public void Jogador_2_deve_ser_o_ganhador_com_um_royal_flush()
        // {
        //     const string ganhadorEsperado = "Jogador 2";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
        //         .ComCartas(new[] { "2C", "3S", "8S", "8D", "QD" }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
        //         .ComCartas(new[] { "10H", "JH", "QH", "KH", "AH" }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }

        // [Fact]
        // public void Deve_resultar_em_empate_caso_ambos_os_jogadores_possuam_um_royal_flush()
        // {
        //     const string ganhadorEsperado = "Empate";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
        //         .ComCartas(new[] { "10D", "JD", "QD", "KD", "AD" }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
        //         .ComCartas(new[] { "10H", "JH", "QH", "KH", "AH" }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }
        
        // [Theory]
        // [InlineData("5H", "2H", "6H", "3H", "4H")]
        // [InlineData("KD", "9D", "JD", "10D", "QD")]
        // [InlineData("5C", "6C", "7C", "8C", "9C")]
        // [InlineData("2S", "5S", "6S", "3S", "4S")]
        // public void Jogador_1_deve_ser_o_ganhador_com_um_straight_flush(
        //     string carta1DoJogador1, string carta2DoJogador1, string carta3DoJogador1, string carta4DoJogador1, string carta5DoJogador1)
        // {
        //     const string ganhadorEsperado = "Jogador 1";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
        //         .ComCartas(new[] { 
        //             carta1DoJogador1,
        //             carta2DoJogador1,
        //             carta3DoJogador1,
        //             carta4DoJogador1,
        //             carta5DoJogador1  
        //         }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
        //         .ComCartas(new[] { "2C", "3S", "8S", "8D", "QD" }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }

        // [Theory]
        // [InlineData("5H", "2H", "6H", "3H", "4H")]
        // [InlineData("KD", "9D", "JD", "10D", "QD")]
        // [InlineData("5C", "6C", "7C", "8C", "9C")]
        // [InlineData("2S", "5S", "6S", "3S", "4S")]
        // public void Jogador_2_deve_ser_o_ganhador_com_um_straight_flush(
        //     string carta1DoJogador2, string carta2DoJogador2, string carta3DoJogador2, string carta4DoJogador2, string carta5DoJogador2)
        // {
        //     const string ganhadorEsperado = "Jogador 2";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
        //         .ComCartas(new[] { "2C", "3S", "8S", "8D", "JD" }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
        //         .ComCartas(new[] { 
        //             carta1DoJogador2,
        //             carta2DoJogador2,
        //             carta3DoJogador2,
        //             carta4DoJogador2,
        //             carta5DoJogador2 
        //          }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }

        // [Fact]
        // public void Jogador_1_deve_ganhar_no_desempate_com_um_straight_flush()
        // {
        //     const string ganhadorEsperado = "Jogador 1";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
        //         .ComCartas(new[] { "KD", "9D", "JD", "10D", "QD" }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
        //         .ComCartas(new[] { "5H", "2H", "6H", "3H", "4H" }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }

        // [Fact]
        // public void Jogador_2_deve_ganhar_no_desempate_com_um_straight_flush()
        // {
        //     const string ganhadorEsperado = "Jogador 2";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
        //         .ComCartas(new[] { "2D", "6D", "4D", "3D", "5D" }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
        //         .ComCartas(new[] { "9H", "JH", "10H", "8H", "7H" }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }

        // [Theory]
        // [InlineData("2D", "2H", "2C", "2S", "5D")]
        // [InlineData("QD", "QH", "QC", "QS", "AD")]
        // [InlineData("10D", "10H", "10C", "2S", "10S")]
        // public void Jogador_1_deve_ganhar_com_uma_quadra(
        //     string carta1DoJogador1, string carta2DoJogador1, string carta3DoJogador1, string carta4DoJogador1, string carta5DoJogador1
        // )
        // {
        //     const string ganhadorEsperado = "Jogador 1";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
        //         .ComCartas(new[] { 
        //             carta1DoJogador1, 
        //             carta2DoJogador1, 
        //             carta3DoJogador1, 
        //             carta4DoJogador1, 
        //             carta5DoJogador1
        //         }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
        //         .ComCartas(new[] { "9H", "3S", "10C", "4D", "QH" }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }

        // [Theory]
        // [InlineData("2D", "6H", "6C", "6S", "6D")]
        // [InlineData("JD", "JH", "JC", "JS", "5D")]
        // [InlineData("AD", "AH", "AC", "AS", "QS")]
        // public void Jogador_2_deve_ganhar_com_uma_quadra(
        //     string carta1DoJogador2, string carta2DoJogador2, string carta3DoJogador2, string carta4DoJogador2, string carta5DoJogador2
        // )
        // {
        //     const string ganhadorEsperado = "Jogador 2";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
        //         .ComCartas(new[] { "KH", "2S", "7C", "10D", "QH" }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
        //         .ComCartas(new[] { 
        //             carta1DoJogador2, 
        //             carta2DoJogador2, 
        //             carta3DoJogador2, 
        //             carta4DoJogador2, 
        //             carta5DoJogador2
        //         }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }

        // [Fact]
        // public void Jogador_1_deve_ganhar_no_desempate_com_uma_quadra()
        // {
        //     const string ganhadorEsperado = "Jogador 1";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
        //         .ComCartas(new[] { "AH", "AS", "AC", "AD", "QH" }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
        //         .ComCartas(new[] { "10H", "10S", "10C", "10D", "2H" }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }

        // [Fact]
        // public void Jogador_2_deve_ganhar_no_desempate_com_uma_quadra()
        // {
        //     const string ganhadorEsperado = "Jogador 2";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
        //         .ComCartas(new[] { "6H", "6S", "6C", "6D", "KH" }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
        //         .ComCartas(new[] { "10H", "10S", "10C", "10D", "JH" }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }

        // [Theory]
        // [InlineData("2D", "6H", "6C", "2S", "2H")]
        // [InlineData("AH", "AC", "AS", "QC", "QD")]
        // [InlineData("10D", "KH", "10C", "10S", "KD")]
        // public void Jogador_1_deve_ganhar_com_um_full_house(
        //     string carta1DoJogador1, string carta2DoJogador1, string carta3DoJogador1, string carta4DoJogador1, string carta5DoJogador1
        // )
        // {
        //     const string ganhadorEsperado = "Jogador 1";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
        //         .ComCartas(new[] { 
        //             carta1DoJogador1, 
        //             carta2DoJogador1, 
        //             carta3DoJogador1, 
        //             carta4DoJogador1, 
        //             carta5DoJogador1
        //         }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
        //         .ComCartas(new[] {"6H", "10S", "QC", "4D", "AH" }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }

        // [Theory]
        // [InlineData("10D", "AH", "10C", "AS", "10H")]
        // [InlineData("QH", "QC", "QS", "KC", "KD")]
        // [InlineData("2D", "2H", "AC", "AS", "AD")]
        // public void Jogador_2_deve_ganhar_com_um_full_house(
        //     string carta1DoJogador2, string carta2DoJogador2, string carta3DoJogador2, string carta4DoJogador2, string carta5DoJogador2
        // )
        // {
        //     const string ganhadorEsperado = "Jogador 2";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
        //         .ComCartas(new[] { "10D", "QS", "4C", "4D", "7H" }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
        //         .ComCartas(new[] { 
        //             carta1DoJogador2, 
        //             carta2DoJogador2, 
        //             carta3DoJogador2, 
        //             carta4DoJogador2, 
        //             carta5DoJogador2
        //         }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }

        // [Fact]
        // public void Jogador_1_deve_ganhar_no_desempate_com_um_full_house_e_uma_trinca_de_maior_valor()
        // {
        //     const string ganhadorEsperado = "Jogador 1";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
        //         .ComCartas(new[] { "9H", "AS", "AC", "9D", "9C" }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
        //         .ComCartas(new[] { "8H", "8S", "8C", "AD", "AH" }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }

        // [Fact]
        // public void Jogador_2_deve_ganhar_no_desempate_com_um_full_house_e_uma_trinca_de_maior_valor()
        // {
        //     const string ganhadorEsperado = "Jogador 2";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
        //         .ComCartas(new[] { "6H", "6S", "KC", "KD", "10H" }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
        //         .ComCartas(new[] { "JH", "6D", "6C", "JD", "JC" }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }

        // [Theory]
        // [InlineData("2H", "6H", "AH", "KH", "3H")]
        // [InlineData("AC", "7C", "10C", "QC", "JC")]
        // [InlineData("10D", "KD", "5D", "JD", "QD")]
        // public void Jogador_1_deve_ganhar_com_um_flush(
        //     string carta1DoJogador1, string carta2DoJogador1, string carta3DoJogador1, string carta4DoJogador1, string carta5DoJogador1
        // )
        // {
        //     const string ganhadorEsperado = "Jogador 1";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
        //         .ComCartas(new[] { 
        //             carta1DoJogador1,
        //             carta2DoJogador1,
        //             carta3DoJogador1,
        //             carta4DoJogador1,
        //             carta5DoJogador1
        //         }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
        //         .ComCartas(new[] { "AD", "QH", "QC", "2S", "9D" }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }

        // [Theory]
        // [InlineData("QC", "10C", "AC", "KC", "7C")]
        // [InlineData("10H", "7H", "2H", "4H", "AH")]
        // [InlineData("10D", "KD", "5D", "JD", "QD")]
        // public void Jogador_2_deve_ganhar_com_um_flush(
        //     string carta1DoJogador2, string carta2DoJogador2, string carta3DoJogador2, string carta4DoJogador2, string carta5DoJogador2
        // )
        // {
        //     const string ganhadorEsperado = "Jogador 2";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
        //         .ComCartas(new[] { "KC", "10S", "2C", "2S", "9H" }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
        //         .ComCartas(new[] { 
        //             carta1DoJogador2,
        //             carta2DoJogador2,
        //             carta3DoJogador2,
        //             carta4DoJogador2,
        //             carta5DoJogador2
        //         }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }

        // [Fact]
        // public void Jogador_1_deve_ganhar_no_desempate_com_um_flush()
        // {
        //     const string ganhadorEsperado = "Jogador 1";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
        //         .ComCartas(new[] { "2H", "3H", "6H", "9H", "AH" }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
        //         .ComCartas(new[] { "QC", "10C", "JC", "KC", "7C" }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }

        // [Fact]
        // public void Jogador_2_deve_ganhar_no_desempate_com_um_flush()
        // {
        //     const string ganhadorEsperado = "Jogador 2";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
        //         .ComCartas(new[] { "2H", "3H", "6H", "9H", "JH" }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
        //         .ComCartas(new[] { "QC", "10C", "JC", "KC", "7C" }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }

        // [Theory]
        // [InlineData("2C", "6D", "5H", "3S", "4C")]
        // [InlineData("9C", "8D", "7S", "6H", "10H")]
        // [InlineData("10D", "QC", "KD", "JH", "9C")]
        // public void Jogador_1_deve_ganhar_com_um_straight(
        //     string carta1DoJogador1, string carta2DoJogador1, string carta3DoJogador1, string carta4DoJogador1, string carta5DoJogador1
        // )
        // {
        //     const string ganhadorEsperado = "Jogador 1";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
        //         .ComCartas(new[] { 
        //             carta1DoJogador1,
        //             carta2DoJogador1,
        //             carta3DoJogador1,
        //             carta4DoJogador1,
        //             carta5DoJogador1
        //         }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
        //         .ComCartas(new[] { "KC", "10S", "2C", "2S", "9H" }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }

        // [Theory]
        // [InlineData("7H", "JC", "8C", "9D", "10S")]
        // [InlineData("3S", "2D", "6C", "4H", "5S")]
        // [InlineData("5D", "6C", "7D", "8H", "9C")]
        // public void Jogador_2_deve_ganhar_com_um_straight(
        //     string carta1DoJogador2, string carta2DoJogador2, string carta3DoJogador2, string carta4DoJogador2, string carta5DoJogador2
        // )
        // {
        //     const string ganhadorEsperado = "Jogador 2";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
        //         .ComCartas(new[] { "AC", "QS", "8D", "10S", "QH" }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
        //         .ComCartas(new[] { 
        //             carta1DoJogador2,
        //             carta2DoJogador2,
        //             carta3DoJogador2,
        //             carta4DoJogador2,
        //             carta5DoJogador2
        //         }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }

        // [Fact]
        // public void Jogador_1_deve_ganhar_no_desempate_com_um_straight()
        // {
        //     const string ganhadorEsperado = "Jogador 1";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
        //         .ComCartas(new[] { "10C", "9S", "8H", "6H", "7D" }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 1")
        //         .ComCartas(new[] { "6C", "9S", "8H", "5H", "7D" }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }

        // [Fact]
        // public void Jogador_2_deve_ganhar_no_desempate_com_um_straight()
        // {
        //     const string ganhadorEsperado = "Jogador 2";
        //     var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
        //         .ComCartas(new[] { "2C", "3S", "4H", "5S", "6D" }).Construir();
        //     var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
        //         .ComCartas(new[] { "7H", "3S", "4H", "5H", "6S" }).Construir();

        //     var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

        //     Assert.Equal(ganhadorEsperado, ganhador);
        // }

        [Theory]
        [InlineData("3S", "2D", "3C", "7H", "3S")]
        [InlineData("KH", "KD", "3C", "7H", "KS")]
        [InlineData("AS", "2D", "3C", "AD", "AC")]
        public void Jogador_1_deve_ganhar_com_uma_trinca(
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
                .ComCartas(new[] { "2D", "6S", "AS", "QH", "QK" }).Construir();

            var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

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
            var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
                .ComCartas(new[] { "KS", "3H", "AS", "10C", "9D" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { 
                    carta1DoJogador2,
                    carta2DoJogador2,
                    carta3DoJogador2,
                    carta4DoJogador2,
                    carta5DoJogador2
                }).Construir();

            var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Fact]
        public void Jogador_1_deve_ganhar_no_desempate_com_uma_trinca()
        {
            const string ganhadorEsperado = "Jogador 1";
            var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { "2D", "3S", "5H", "5C", "5D" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
                .ComCartas(new[] { "2C", "3H", "4D", "4H", "4C" }).Construir();

            var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Fact]
        public void Jogador_2_deve_ganhar_no_desempate_com_uma_trinca()
        {
            const string ganhadorEsperado = "Jogador 2";
            var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
                .ComCartas(new[] { "QS", "KC", "2S", "2C", "2D" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { "4S", "5C", "AS", "AC", "AD" }).Construir();

            var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

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
            var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] {
                    carta1DoJogador1,
                    carta2DoJogador1,
                    carta3DoJogador1,
                    carta4DoJogador1,
                    carta5DoJogador1
                }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
                .ComCartas(new[] { "7C", "QH", "AS", "10C", "10S" }).Construir();

            var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

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
            var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
                .ComCartas(new[] { "AS", "10H", "5C", "10D", "KS" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] {
                    carta1DoJogador2,
                    carta2DoJogador2,
                    carta3DoJogador2,
                    carta4DoJogador2,
                    carta5DoJogador2
                }).Construir();

            var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Fact]
        public void Jogador_1_deve_ganhar_no_desempate_com_dois_pares()
        {
            const string ganhadorEsperado = "Jogador 1";
            var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { "3H", "2C", "2S", "3S", "KD" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
                .ComCartas(new[] { "4S", "QC", "4H", "3C", "3D" }).Construir();

            var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Fact]
        public void Jogador_2_deve_ganhar_no_desempate_com_dois_pares()
        {
            const string ganhadorEsperado = "Jogador 2";
            var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
                .ComCartas(new[] { "7C", "7D", "10S", "10H", "KD" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { "7S", "7H", "10C", "10D", "AD" }).Construir();

            var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

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
            var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { 
                    carta1DoJogador1,
                    carta2DoJogador1,
                    carta3DoJogador1,
                    carta4DoJogador1,
                    carta5DoJogador1
                }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
                .ComCartas(new[] { "2S", "10H", "AS", "JD", "QD" }).Construir();

            var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

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
            var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
                .ComCartas(new[] { "AS", "QH", "6S", "10D", "JD" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { 
                    carta1DoJogador2,
                    carta2DoJogador2,
                    carta3DoJogador2,
                    carta4DoJogador2,
                    carta5DoJogador2
                }).Construir();

            var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Fact]
        public void Jogador_1_deve_ganhar_no_desempate_com_um_par()
        {
            const string ganhadorEsperado = "Jogador 1";
            var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { "3H", "2C", "10D", "10S", "KD" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
                .ComCartas(new[] { "10C", "10H", "4H", "3C", "2D" }).Construir();

            var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }

        [Fact]
        public void Jogador_2_deve_ganhar_no_desempate_com_um_par()
        {
            const string ganhadorEsperado = "Jogador 2";
            var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
                .ComCartas(new[] { "QH", "2C", "QD", "5S", "KD" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { "10C", "AH", "QS", "QC", "2D" }).Construir();

            var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

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
            var jogador1 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] { 
                    carta1DoJogador1,
                    carta2DoJogador1,
                    carta3DoJogador1,
                    carta4DoJogador1,
                    carta5DoJogador1
                }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome("Jogador 2")
                .ComCartas(new[] { "3D", "9H", "2S", "JD", "4D" }).Construir();

            var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

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
            var jogador1 = JogadorBuilder.Instancia().ComNome("Jogador 1")
                .ComCartas(new[] { "6D", "10H", "2S", "7D", "4D" }).Construir();
            var jogador2 = JogadorBuilder.Instancia().ComNome(ganhadorEsperado)
                .ComCartas(new[] {
                    carta1DoJogador2,
                    carta2DoJogador2,
                    carta3DoJogador2,
                    carta4DoJogador2,
                    carta5DoJogador2
                }).Construir();

            var ganhador = AnalisadorDeJogada.ObterGanhador(jogador1, jogador2);

            Assert.Equal(ganhadorEsperado, ganhador);
        }
    }
}
