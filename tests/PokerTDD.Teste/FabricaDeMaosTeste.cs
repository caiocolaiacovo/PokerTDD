using System.Collections.Generic;
using Xunit;

namespace PokerTDD.Teste
{
    public class FabricaDeMaosTeste
    {
        [Fact]
        public void Deve_criar_um_royal_flush()
        {
            var cartas = new List<string> { "10H", "JH", "QH", "KH", "AH" };

            var mao = FabricaDeMaos.Criar(cartas);

            Assert.IsType<RoyalFlush>(mao);
        }

        [Fact]
        public void Deve_criar_um_straight_flush()
        {
            var cartas = new List<string> { "5H", "2H", "6H", "3H", "4H" };

            var mao = FabricaDeMaos.Criar(cartas);

            Assert.IsType<StraightFlush>(mao);
        }

        [Fact]
        public void Deve_criar_uma_quadra()
        {
            var cartas = new List<string> { "2D", "2H", "2C", "2S", "5D" };

            var mao = FabricaDeMaos.Criar(cartas);

            Assert.IsType<Quadra>(mao);
        }

        [Fact]
        public void Deve_criar_um_full_house()
        {
            var cartas = new List<string> { "AH", "AC", "AS", "QC", "QD" };

            var mao = FabricaDeMaos.Criar(cartas);

            Assert.IsType<FullHouse>(mao);
        }

        [Fact]
        public void Deve_criar_um_flush()
        {
            var cartas = new List<string> { "2H", "6H", "AH", "KH", "3H" };

            var mao = FabricaDeMaos.Criar(cartas);

            Assert.IsType<Flush>(mao);
        }

        [Fact]
        public void Deve_criar_um_straight()
        {
            var cartas = new List<string> { "10D", "QC", "KD", "JH", "9C" };

            var mao = FabricaDeMaos.Criar(cartas);

            Assert.IsType<Straight>(mao);
        }

        [Fact]
        public void Deve_criar_uma_trinca()
        {
            var cartas = new List<string> { "KH", "KD", "3C", "7H", "KS" };

            var mao = FabricaDeMaos.Criar(cartas);

            Assert.IsType<Trinca>(mao);
        }

        [Fact]
        public void Deve_criar_um_dois_pares()
        {
            var cartas = new List<string> { "7S", "7D", "KC", "AD", "AC" };

            var mao = FabricaDeMaos.Criar(cartas);

            Assert.IsType<DoisPares>(mao);
        }

        [Fact]
        public void Deve_criar_um_par()
        {
            var cartas = new List<string> { "QS", "2D", "QC", "10H", "3S" };

            var mao = FabricaDeMaos.Criar(cartas);

            Assert.IsType<UmPar>(mao);
        }
    }
}