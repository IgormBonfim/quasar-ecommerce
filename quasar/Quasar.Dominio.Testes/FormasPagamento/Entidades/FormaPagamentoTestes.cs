using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Quasar.Dominio.FormasPagamento.Entidades;
using Xunit;

namespace Quasar.Dominio.Testes.FormasPagamento.Entidades
{
    public class FormaPagamentoTestes
    {
        private readonly FormaPagamento sut;

        public FormaPagamentoTestes()
        {
            sut = Builder<FormaPagamento>.CreateNew().Build();
        }

        public class Construtor
        {
            [Fact]
            public void Quando_ParametrosForemValidos_Espero_ObjetoIntegro()
            {
                //Act
                var formaPagamento = new FormaPagamento("Teste de descrição");

                //Assert
                formaPagamento.Descricao.Should().Be("Teste de descrição");
            }
        }

        public class SetCodigoMetodo : FormaPagamentoTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData(-1)]
            [InlineData(0)]
            public void Dado_ValorNulloOuMenorQueUm_Espero_Exception(int valor)
            {
                sut.Invoking(x => x.SetCodigo(valor)).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_ValorValido_Espero_PropriedadesPreenchidas()
            {
                sut.SetCodigo(1);
                sut.Codigo.Should().Be(1);
            }
        }

        public class SetDescricaoMetodo : FormaPagamentoTestes
        {
            [Theory]
            [InlineData("")]
            [InlineData(" ")]
            [InlineData(null)]
            public void Dado_NomeNuloOuEspacoEmBranco_Espero_Exception(string descricao)
            {
                sut.Invoking(x => x.SetDescricao(descricao)).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_NomeValido_Espero_PropriedadesPreenchidas()
            {
                var desc = "Descrição de teste";

                sut.SetDescricao(desc);
                sut.Descricao.Should().Be(desc);
            }
        }
    }
}