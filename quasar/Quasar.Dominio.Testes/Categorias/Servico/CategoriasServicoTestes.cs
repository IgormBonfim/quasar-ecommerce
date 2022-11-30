using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using NSubstitute;
using Quasar.Dominio.Categorias.Entidades;
using Quasar.Dominio.Categorias.Repositorios;
using Quasar.Dominio.Categorias.Servicos;
using Quasar.Dominio.Categorias.Servicos.Interfaces;
using Xunit;

namespace Quasar.Dominio.Testes.Categorias.Servico
{
    public class CategoriasServicoTestes
    {
        private readonly CategoriasServico sut;
        private readonly ICategoriasRepositorio categoriasRepositorio;
        private readonly ICategoriasServico categoriaServico;
        private readonly Categoria categoriaValida;

        public CategoriasServicoTestes()
        {
            categoriaValida = Builder<Categoria>.CreateNew().Build();
            categoriaServico = Substitute.For<ICategoriasServico>();
            categoriasRepositorio = Substitute.For<ICategoriasRepositorio>();

            sut = new CategoriasServico(categoriasRepositorio);
        }
        public class ValidarMetodo : CategoriasServicoTestes
        {
            [Fact]
            public void Quando_CategoriaNaoForEncontrado_Espero_Exception()
            {
                categoriasRepositorio.Recuperar(Arg.Any<int>()).Returns(Xunit => null);
                sut.Invoking(x => x.Validar(1)).Should().Throw<Exception>();
            }
            [Fact]
            public void Quando_CategoriaForEncontrado_Espero_CategoriaValido()
            {
                categoriasRepositorio.Recuperar(Arg.Any<int>()).Returns(categoriaValida);
                sut.Validar(1).Should().BeSameAs(categoriaValida);
            }
        }
        public class EditarMetodo : CategoriasServicoTestes
        {
            public void Dado_ParametrosParaEditarCategoria_Espero_CategoriaEditado()
            {
                //Arrange
                categoriasRepositorio.Recuperar(Arg.Any<int>()).Returns(categoriaValida);
                categoriasRepositorio.Editar(Arg.Any<Categoria>()).Returns(categoriaValida);
                var categoriaNovo = new Categoria(
                                    "Teste de Nome da Categoria",
                                    "Teste de Imagem da Categoria");
                //Arc
                var categoriaEditado = sut.Editar(categoriaNovo);
                //Assert
                categoriaEditado.Nome.Should().Be("Teste de Nome da Categoria");
                categoriaEditado.Imagem.Should().Be("Teste de Imagem da Categoria");
            }
        }
        public class InserirMetodo : CategoriasServicoTestes
        {
            [Fact]
            public void Dado_CategoriaValida_Espero_CategoriaValido()
            {
                sut.Inserir(categoriaValida);
                categoriasRepositorio.Received(1).Inserir(categoriaValida);
            }
        }
        public class InstanciarMetodo :CategoriasServicoTestes
        {
            public void Dado_ParametrosParaCriarCategoria_Espero_CategoriaInstanciado()
            {
                var categoria = sut.Instanciar(
                                "Teste de Nome da Categoria",
                                "Teste de Imagem da Categoria");
                categoria.Should().NotBeNull();
            }
        }
    }
}
