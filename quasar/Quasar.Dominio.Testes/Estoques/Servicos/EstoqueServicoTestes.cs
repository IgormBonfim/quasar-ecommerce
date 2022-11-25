using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using NSubstitute;
using Quasar.Dominio.Estoques.Entidades;
using Quasar.Dominio.Estoques.Respositorios;
using Quasar.Dominio.Estoques.Servicos;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Produtos.Servicos.Interfaces;
using Xunit;

namespace Quasar.Dominio.Testes.Estoques.Servicos
{
    public class EstoqueServicoTestes
    {
        private readonly EstoquesServico sut;   
        private readonly IEstoquesRepositorio estoquesRepositorio;
        private readonly IProdutosServico produtosServicos;

        private readonly Estoque estoqueValido;
        private readonly Produto produtoValido;

        public EstoqueServicoTestes()
        {
            estoqueValido = Builder<Estoque>.CreateNew().Build();
            produtoValido = Builder<Produto>.CreateNew().Build();

            estoquesRepositorio = Substitute.For<IEstoquesRepositorio>();
            produtosServicos = Substitute.For<IProdutosServico>();

            sut = new EstoquesServico(estoquesRepositorio, produtosServicos);
        }

        public class ValidarMetodo : EstoqueServicoTestes
        {
            [Fact]
            public void Quando_QuantidadeNaoForEncontrada_Espero_Exception()
            {
                estoquesRepositorio.Recuperar(Arg.Any<int>()).Returns(x => null);
                sut.Invoking(x => x.Validar(1)).Should().Throw<Exception>();
            }
            [Fact]
            public void Quando_QuantidadeForEncontrada_Espero_ProdutoValido()
            {
                estoquesRepositorio.Recuperar(Arg.Any<int>()).Returns(estoqueValido);
                sut.Validar(1).Should().BeSameAs(estoqueValido);
            } 
        }
        public class EditarMetodo : EstoqueServicoTestes
        {
            [Fact]
            public void Dado_ParametrosParaEditarEstoque_Espero_EstoqueEditado()
            {   
                //Arrange
               estoquesRepositorio.Recuperar(Arg.Any<int>()).Returns(estoqueValido);
               estoquesRepositorio.Editar(Arg.Any<Estoque>()).Returns(estoqueValido);

               var estoqueNovo = new Estoque(2, produtoValido);

                //Act
               var estoqueEditado = sut.Editar(estoqueNovo); 

                //Assert
               estoqueEditado.Quantidade.Should().Be(2);
            }
        }
        public class InserirMetodo : EstoqueServicoTestes
        {
            [Fact]
            public void Dado_EstoqueValido_Espero_EstoqueValido()
            {
                sut.Inserir(estoqueValido);
                estoquesRepositorio.Received(1).Inserir(estoqueValido);
            }
        }
        public class InstanciarMetodo : EstoqueServicoTestes
        {
            [Fact]
            public void Dado_ParametrosParaCriarEstoque_Espero_EstoqueInstanciado()
            {
                var estoque = sut.Instanciar(1,1);
                estoque.Should().NotBeNull();
            }
        }
    }
}