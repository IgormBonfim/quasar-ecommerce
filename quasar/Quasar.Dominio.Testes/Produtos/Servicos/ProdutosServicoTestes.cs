using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using NSubstitute;
using Quasar.Dominio.Categorias.Entidades;
using Quasar.Dominio.Categorias.Servicos.Interfaces;
using Quasar.Dominio.Fornecedores.Entidades;
using Quasar.Dominio.Fornecedores.Servicos.Interfaces;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Produtos.Repositorios;
using Quasar.Dominio.Produtos.Servicos;
using Quasar.Dominio.Produtos.Servicos.Interfaces;
using Xunit;

namespace Quasar.Dominio.Testes.Produtos.Servicos
{
    public class ProdutosServicoTestes
    {
        private readonly ProdutosServico sut;
        private readonly IProdutosRepositorio produtosRepositorio;
        private readonly IEspecificacoesServico especificacaoServico;
        private readonly ICategoriasServico categoriaServico;
        private readonly IFornecedoresServico fornecedorServico;

        private readonly Produto produtoValido;
        private readonly Especificacao especificacaoValida;
        private readonly Categoria categoriaValida;
        private readonly Fornecedor fornecedorValido;

        public ProdutosServicoTestes()
        {
            produtoValido = Builder<Produto>.CreateNew().Build();
            especificacaoValida = Builder<Especificacao>.CreateNew().Build();
            categoriaValida = Builder<Categoria>.CreateNew().Build();
            fornecedorValido = Builder<Fornecedor>.CreateNew().Build();

            produtosRepositorio = Substitute.For<IProdutosRepositorio>();
            especificacaoServico = Substitute.For<IEspecificacoesServico>();
            categoriaServico = Substitute.For<ICategoriasServico>();
            fornecedorServico = Substitute.For<IFornecedoresServico>();

            sut = new ProdutosServico(produtosRepositorio, especificacaoServico, categoriaServico, fornecedorServico);
        }

        public class ValidarMetodo : ProdutosServicoTestes
        {
            [Fact]
            public void Quando_ProdutoNaoForEncontrado_Espero_Exception()
            {
                produtosRepositorio.Recuperar(Arg.Any<int>()).Returns(x => null);

                sut.Invoking(x => x.Validar(1)).Should().Throw<Exception>();
            }

            [Fact]
            public void Quando_ProdutoForEncontrado_Espero_ProdutoValido()
            {
                produtosRepositorio.Recuperar(Arg.Any<int>()).Returns(produtoValido);
                sut.Validar(1).Should().BeSameAs(produtoValido);
            }
        }
    }
}