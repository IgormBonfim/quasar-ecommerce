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