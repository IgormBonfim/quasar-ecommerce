using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Quasar.Dominio.Categorias.Entidades;
using Quasar.Dominio.Fornecedores.Entidades;
using Quasar.Dominio.Produtos.Entidades;
using Xunit;

namespace Quasar.Dominio.Testes.Produtos.Entidades
{
    public class ProdutoTestes
    {
        private readonly Produto sut;

        public ProdutoTestes()
        {
            sut = Builder<Produto>.CreateNew().Build();
        }

        public class Construtor
        {
            [Fact]
            public void Quando_ParametrosForemValidos_Espero_ObjetoIntegro()
            {
                // Arrange
                var especificacao = Builder<Especificacao>.CreateNew().Build();
                var categoria = Builder<Categoria>.CreateNew().Build();
                var fornecedor = Builder<Fornecedor>.CreateNew().Build();

                // Act
                var produto = new Produto(
                    "Testes de Descrição de um Produto", 
                    "Vidro de teste",
                    1500.50M,
                    "https://www.imagemdeteste.com.br",
                    especificacao,
                    categoria,
                    fornecedor);

                // Assert
                produto.Descricao.Should().Be("Testes de Descrição de um Produto");
                produto.Nome.Should().Be("Vidro de teste");
                produto.Valor.Should().Be(1500.50M);
                produto.Imagem.Should().Be("https://www.imagemdeteste.com.br");
                produto.Especificacao.Should().BeSameAs(especificacao);
                produto.Categoria.Should().BeSameAs(categoria);
                produto.Fornecedor.Should().BeSameAs(fornecedor);
            }
        }
        
        public class SetNomeMetodo : ProdutoTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData(" ")]
            public void Dado_NomeNuloOuEspacoEmBranco_Espero_Exception(string nome)
            {
                sut.Invoking(x => x.SetNome(nome)).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_NomeComMenosDeDezCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetNome(new string('*', 9))).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_NomeComMaisDeCemCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetNome(new string('*', 101))).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_NomeValido_Espero_PropriedadesPreenchidas()
            {
                sut.SetNome("Vidro de teste");
                sut.Nome.Should().Be("Vidro de teste");
            }
        }

        public class SetEspecificacaoMetodo : ProdutoTestes
        {
            [Theory]
            [InlineData(null)]
            public void Quando_EspecificacaoForNulo_Espero_Exception(Especificacao especificacao)
            {
                sut.Invoking(x => x.SetEspecificacao(especificacao)).Should().Throw<Exception>();
            }

            [Fact]
            public void Quando_EspecificacaoForValido_Espero_PropriedadePreenchida()
            {
                var especificacao = Builder<Especificacao>.CreateNew().Build();
                sut.SetEspecificacao(especificacao);
                sut.Especificacao.Should().BeSameAs(especificacao);
            }
        }

        public class SetCategoriaMetodo : ProdutoTestes
        {
            [Theory]
            [InlineData(null)]
            public void Quando_CategoriaForNulo_Espero_Exception(Categoria categoria)
            {
                sut.Invoking(x => x.SetCategoria(categoria)).Should().Throw<Exception>();
            }

            [Fact]
            public void Quando_CategoriaForValido_Espero_PropriedadePreenchida()
            {
                var categoria = Builder<Categoria>.CreateNew().Build();
                sut.SetCategoria(categoria);
                sut.Categoria.Should().BeSameAs(categoria);
            }
        }
    }
}