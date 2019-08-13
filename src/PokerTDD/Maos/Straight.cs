﻿using System;
using System.Collections.Generic;
using System.Linq;
using PokerTDD.Cartas;

namespace PokerTDD.Maos
{
    public class Straight : Mao
    {
        public Straight(List<Carta> cartas) : base((int)ValorDaMao.Straight, cartas)
        {
            if (!Validar(cartas))
                throw new Exception("As cartas informadas não são válidas para esta mão");

            CartaMaisAlta = ObterCartaMaisAlta();
        }

        public static bool Validar(List<Carta> cartas)
        {
            if (cartas == null || !cartas.Any())
                return false;

            var cartasOrdenadas = cartas.OrderBy(c => c.Valor).ToList();
            var valorDaPrimeiraCarta = cartasOrdenadas.Select(c => c.Valor).First();
            var cartasEstaoEmSequencia = true;

            foreach (var carta in cartasOrdenadas)
            {
                if (carta.Valor != valorDaPrimeiraCarta) {
                    cartasEstaoEmSequencia = false;
                    break;
                }

                valorDaPrimeiraCarta++;
            }

            return cartasEstaoEmSequencia;
        }

        private Carta ObterCartaMaisAlta()
        {
            return Cartas.OrderByDescending(c => c.Valor).First();
        }
    }
}
