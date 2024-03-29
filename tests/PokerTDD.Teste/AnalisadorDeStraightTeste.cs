﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PokerTDD.Teste
{
    public class AnalisadorDeStraightTeste
    {
        private AnalisadorDeStraight _analisador;

        public AnalisadorDeStraightTeste()
        {
            _analisador = new AnalisadorDeStraight();
        }

        [Fact]
        public void Deve_ser_um_analisador_de_mao()
        {
            Assert.True(_analisador is IAnalisadorDeMao);
            Assert.True(_analisador is AnalisadorDeMaoBase);
        }

        [Theory]
        [InlineData("2C", "6D", "5H", "3S", "4C")]
        [InlineData("9C", "8D", "7S", "6H", "10H")]
        [InlineData("10D", "QC", "KD", "JH", "9C")]
        [InlineData("7H", "JC", "8C", "9D", "10S")]
        [InlineData("3S", "2D", "6C", "4H", "5S")]
        public void Deve_ser_uma_mao_valida(
            string carta1, string carta2, string carta3, string carta4, string carta5
        )
        {
            var mao = new[]
            {
                carta1,
                carta2,
                carta3,
                carta4,
                carta5
            };
            var ehValida = _analisador.EhValida(mao);

            Assert.True(ehValida);
        }

        [Theory]
        [InlineData("2C", "6D", "10H", "3S", "4C")]
        [InlineData("9C", "8D", "AS", "6H", "10H")]
        public void Nao_deve_ser_uma_mao_valida(
            string carta1, string carta2, string carta3, string carta4, string carta5
        )
        {
            var mao = new[]
            {
                carta1,
                carta2,
                carta3,
                carta4,
                carta5
            };
            var ehValida = _analisador.EhValida(mao);

            Assert.False(ehValida);
        }

        [Fact]
        public void Deve_possuir_a_ordem_6()
        {
            const int ordemEsperada = 6;

            var ordem = _analisador.Ordem;

            Assert.Equal(ordemEsperada, ordem);
        }

        [Fact]
        public void Nao_deve_ser_uma_mao_valida_caso_seja_informada_uma_mao_vazia()
        {
            const string mensagemDeErroEsperada = "É obrigatório informar uma mão para validar";

            void Acao() => _analisador.EhValida(new string[]{});

            var mensagemDeErro = Assert.Throws<ArgumentException>(Acao).Message;
            Assert.Equal(mensagemDeErroEsperada, mensagemDeErro);
        }

        [Fact]
        public void Nao_deve_ser_uma_mao_valida_caso_seja_informada_uma_mao_nula()
        {
            const string mensagemDeErroEsperada = "É obrigatório informar uma mão para validar";

            void Acao() => _analisador.EhValida(null);

            var mensagemDeErro = Assert.Throws<ArgumentException>(Acao).Message;
            Assert.Equal(mensagemDeErroEsperada, mensagemDeErro);
        }
    }
}
