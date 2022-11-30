using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Quasar.Dominio.Estoques.Entidades;
using Quasar.Dominio.Produtos.Entidades;
using Xunit;

namespace Quasar.Dominio.Testes.Estoques.Entidades
{
    public class EstoqueTestes
    {
        private readonly Estoque sut;

        public EstoqueTestes ()
        {
            sut = Builder<Estoque>.CreateNew().Build();
        }

        public class Construtor
        {
            [Fact]
            public void Quando_ParametrosForemValidos_Espero_ObjetoIntegro()
            {
                // Arrange
                var produto = Builder<Produto>.CreateNew().Build();
            
                // Act
                var estoque = new Estoque(
                    20,
                    produto);
                // Assert
                estoque.Quantidade.Should().Be(20);
                estoque.Produto.Should().BeSameAs(produto);
            }
        }
        public class SetCodigoMetodo : EstoqueTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData(-1)]
            [InlineData(0)]
            public void Dado_ValorNulloOuMenorQueUm_Espero_Exception(int codigo)
            {
                sut.Invoking(x => x.SetCodigo(codigo)).Should().Throw<Exception>();
            }
            [Fact]
            public void Dado_ValorValido_Espero_PropriedadesPreenchidas()
            {
                sut.SetCodigo(1);
                sut.Codigo.Should().Be(1);
            }
        }
        public class SetQuantidadeMetodo : EstoqueTestes
        {
            [Fact]
            public void Dado_QuantidadeNegativa_Espero_Exception()
            {
                sut.Invoking(x => x.SetQuantidade(-1)).Should().Throw<Exception>();
            }
            [Fact]
            public void Dado_QuantidadeZero_Espero_Exception()
            {
                sut.Invoking(x => x.SetQuantidade(null)).Should().Throw<Exception>();
            }

        }
    }
}