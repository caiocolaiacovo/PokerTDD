using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerTDD
{
    public class AnalisadorDeQuadra : AnalisadorDeMaoBase, IAnalisadorDeMao
    {
        public int Ordem => 3;

        public override int ObterMaiorCartaDaMao(IEnumerable<string> maoDoJogador)
        {
            var cartasSemNaipe = maoDoJogador.Select(ObterCartaSemNaipe);

            var quadra = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 4).First();

            return quadra.First();
        }

        public bool EhValida(IEnumerable<string> cartas)
        {
            if (cartas == null || cartas.Count() == 0)
                throw new ArgumentException("É obrigatório informar uma mão para validar");
                
            var cartasSemNaipe = cartas.Select(ObterCartaSemNaipe);

            var possuiQuatroCartasIguais = cartasSemNaipe.GroupBy(c => c).Where(g => g.Count() == 4).Any();

            return possuiQuatroCartasIguais;
        }
    }
}