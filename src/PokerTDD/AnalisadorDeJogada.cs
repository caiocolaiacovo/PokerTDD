using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeJogada
    {
        public static string ObterGanhador(Jogador jogador1, Jogador jogador2)
        {
            // var jogador1PossuiUmRoyalFlush = AnalisadorDeRoyalFlush.EhUmaMaoValida(jogador1.Cartas);
            // var jogador2PossuiUmRoyalFlush = AnalisadorDeRoyalFlush.EhUmaMaoValida(jogador2.Cartas);

            // if (jogador1PossuiUmRoyalFlush && !jogador2PossuiUmRoyalFlush)
            //     return jogador1.Nome;

            // if (jogador2PossuiUmRoyalFlush && !jogador1PossuiUmRoyalFlush)
            //     return jogador2.Nome;

            // if (jogador1PossuiUmRoyalFlush && jogador2PossuiUmRoyalFlush)
            //     return "Empate";

            // var jogador1PossuiUmStraightFlush = AnalisadorDeStraightFlush.EhUmaMaoValida(jogador1.Cartas);
            // var jogador2PossuiUmStraightFlush = AnalisadorDeStraightFlush.EhUmaMaoValida(jogador2.Cartas);

            // if (jogador1PossuiUmStraightFlush && !jogador2PossuiUmStraightFlush)
            //     return jogador1.Nome;

            // if (jogador2PossuiUmStraightFlush && !jogador1PossuiUmStraightFlush)
            //     return jogador2.Nome;

            // if (jogador1PossuiUmStraightFlush && jogador2PossuiUmStraightFlush)
            // {
            //     var maiorCartaDoJogador1 = ObterMaiorCartaDaMao(jogador1.Cartas, "StraightFlush");
            //     var maiorCartaDoJogador2 = ObterMaiorCartaDaMao(jogador2.Cartas, "StraightFlush");

            //     if (maiorCartaDoJogador1 > maiorCartaDoJogador2)
            //         return jogador1.Nome;
                
            //     return jogador2.Nome;
            // }

            // var jogador1PossuiUmaQuadra = AnalisadorDeQuadra.EhUmaMaoValida(jogador1.Cartas);
            // var jogador2PossuiUmaQuadra = AnalisadorDeQuadra.EhUmaMaoValida(jogador2.Cartas);

            // if (jogador1PossuiUmaQuadra && !jogador2PossuiUmaQuadra)
            //     return jogador1.Nome;

            // if (jogador2PossuiUmaQuadra && !jogador1PossuiUmaQuadra)
            //     return jogador2.Nome;

            // if (jogador1PossuiUmaQuadra && jogador2PossuiUmaQuadra)
            // {
            //     var maiorCartaDoJogador1 = ObterMaiorCartaDaMao(jogador1.Cartas, "Quadra");
            //     var maiorCartaDoJogador2 = ObterMaiorCartaDaMao(jogador2.Cartas, "Quadra");

            //     if (maiorCartaDoJogador1 > maiorCartaDoJogador2)
            //         return jogador1.Nome;
                
            //     return jogador2.Nome;
            // }

            // var jogador1PossuiUmFullHouse = AnalisadorDeFullHouse.EhUmaMaoValida(jogador1.Cartas);
            // var jogador2PossuiUmFullHouse = AnalisadorDeFullHouse.EhUmaMaoValida(jogador2.Cartas);

            // if (jogador1PossuiUmFullHouse && !jogador2PossuiUmFullHouse)
            //     return jogador1.Nome;

            // if (jogador2PossuiUmFullHouse && !jogador1PossuiUmFullHouse)
            //     return jogador2.Nome;

            // if (jogador1PossuiUmFullHouse && jogador2PossuiUmFullHouse)
            // {
            //     var maiorCartaDoJogador1 = ObterMaiorCartaDaMao(jogador1.Cartas, "FullHouse");
            //     var maiorCartaDoJogador2 = ObterMaiorCartaDaMao(jogador2.Cartas, "FullHouse");

            //     if (maiorCartaDoJogador1 > maiorCartaDoJogador2)
            //         return jogador1.Nome;

            //     return jogador2.Nome;
            // }

            // var jogador1PossuiUmFlush = AnalisadorDeFlush.EhUmaMaoValida(jogador1.Cartas);
            // var jogador2PossuiUmFlush = AnalisadorDeFlush.EhUmaMaoValida(jogador2.Cartas);

            // if (jogador1PossuiUmFlush && !jogador2PossuiUmFlush)
            //     return jogador1.Nome;

            // if (jogador2PossuiUmFlush && !jogador1PossuiUmFlush)
            //     return jogador2.Nome;

            // if (jogador1PossuiUmFlush && jogador2PossuiUmFlush)
            // {
            //     var maiorCartaDoJogador1 = ObterMaiorCartaDaMao(jogador1.Cartas, "Flush");
            //     var maiorCartaDoJogador2 = ObterMaiorCartaDaMao(jogador2.Cartas, "Flush");

            //     if (maiorCartaDoJogador1 > maiorCartaDoJogador2)
            //         return jogador1.Nome;

            //     return jogador2.Nome;
            // }

            // var jogador1PossuiUmStraight = AnalisadorDeStraight.EhUmaMaoValida(jogador1.Cartas);
            // var jogador2PossuiUmStraight = AnalisadorDeStraight.EhUmaMaoValida(jogador2.Cartas);

            // if (jogador1PossuiUmStraight && !jogador2PossuiUmStraight)
            //     return jogador1.Nome;

            // if (jogador2PossuiUmStraight && !jogador1PossuiUmStraight)
            //     return jogador2.Nome;

            // if (jogador1PossuiUmStraight && jogador2PossuiUmStraight)
            // {
            //     var maiorCartaDoJogador1 = ObterMaiorCartaDaMao(jogador1.Cartas, "Straight");
            //     var maiorCartaDoJogador2 = ObterMaiorCartaDaMao(jogador2.Cartas, "Straight");

            //     if (maiorCartaDoJogador1 > maiorCartaDoJogador2)
            //         return jogador1.Nome;

            //     return jogador2.Nome;
            // }

            var jogador1PossuiUmaTrinca = AnalisadorDeTrinca.EhUmaMaoValida(jogador1.Cartas);
            var jogador2PossuiUmaTrinca = AnalisadorDeTrinca.EhUmaMaoValida(jogador2.Cartas);

            if (jogador1PossuiUmaTrinca && !jogador2PossuiUmaTrinca)
                return jogador1.Nome;

            if (jogador2PossuiUmaTrinca && !jogador1PossuiUmaTrinca)
                return jogador2.Nome;

            if (jogador1PossuiUmaTrinca && jogador2PossuiUmaTrinca)
            {
                var maiorCartaDoJogador1 = ObterMaiorCartaDaMao(jogador1.Cartas, "Trinca");
                var maiorCartaDoJogador2 = ObterMaiorCartaDaMao(jogador2.Cartas, "Trinca");

                if (maiorCartaDoJogador1 > maiorCartaDoJogador2)
                    return jogador1.Nome;

                return jogador2.Nome;
            }

            var jogador1PossuiDoisPares = AnalisadorDeDoisPares.EhUmaMaoValida(jogador1.Cartas);
            var jogador2PossuiDoisPares = AnalisadorDeDoisPares.EhUmaMaoValida(jogador2.Cartas);

            if (jogador1PossuiDoisPares && !jogador2PossuiDoisPares)
                return jogador1.Nome;

            if (jogador2PossuiDoisPares && !jogador1PossuiDoisPares)
                return jogador2.Nome;

            if (jogador1PossuiDoisPares && jogador2PossuiDoisPares)
            {
                var maiorCartaDoJogador1 = ObterMaiorCartaDaMao(jogador1.Cartas, "DoisPares");
                var maiorCartaDoJogador2 = ObterMaiorCartaDaMao(jogador2.Cartas, "DoisPares");

                if (maiorCartaDoJogador1 > maiorCartaDoJogador2)
                    return jogador1.Nome;

                return jogador2.Nome;
            }
            
            var jogador1PossuiUmPar = AnalisadorDeUmPar.EhUmaMaoValida(jogador1.Cartas);
            var jogador2PossuiUmPar = AnalisadorDeUmPar.EhUmaMaoValida(jogador2.Cartas);

            if (jogador1PossuiUmPar && !jogador2PossuiUmPar)
                return jogador1.Nome;

            if (jogador2PossuiUmPar && !jogador1PossuiUmPar)
                return jogador2.Nome;

            if (jogador1PossuiUmPar && jogador2PossuiUmPar)
            {
                var maiorCartaDoJogador1 = ObterMaiorCartaDaMao(jogador1.Cartas, "UmPar");
                var maiorCartaDoJogador2 = ObterMaiorCartaDaMao(jogador2.Cartas, "UmPar");

                if (maiorCartaDoJogador1 > maiorCartaDoJogador2)
                    return jogador1.Nome;

                return jogador2.Nome;
            }

            var cartaAltaDoJogador1 = ObterMaiorCartaDaMao(jogador1.Cartas, "CartaAlta");
            var cartaAltaDoJogador2 = ObterMaiorCartaDaMao(jogador2.Cartas, "CartaAlta");

            if (cartaAltaDoJogador1 > cartaAltaDoJogador2)
                return jogador1.Nome;

            return jogador2.Nome;
        }

        private static int ObterMaiorCartaDaMao(IEnumerable<string> maoDoJogador, string mao)
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

            // if (mao.Equals("Quadra"))
            // {
            //     var cartasSemNaipe = maoDoJogador.Select(ObterCartaSemNaipe);

            //     var quadra = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 4).First();

            //     return quadra.First();
            // }

            // if (mao.Equals("FullHouse"))
            // {
            //     var cartasSemNaipe = maoDoJogador.Select(ObterCartaSemNaipe);

            //     var trinca = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 3).First();

            //     return trinca.First();
            // }

            if (mao.Equals("Trinca"))
            {
                var cartasSemNaipe = maoDoJogador.Select(ObterCartaSemNaipe);

                var trinca = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 3).First();

                return trinca.First();
            }

            return 0;
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
    }
}