using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using NSubstitute;
using Quasar.Dominio.Fornecedores.Entidades;
using Quasar.Dominio.Fornecedores.Repositorios;
using Quasar.Dominio.Fornecedores.Servicos;
using Xunit;

namespace Quasar.Dominio.Testes.Fornecedores.Servicos
{
    public class FornecedoresServicoTestes
    {
        private readonly FornecedoresServico sut;
        private readonly IFornecedoresRepositorio fornecedoresRepositorio;

        private readonly Fornecedor fornecedorValido;
        
        public FornecedoresServicoTestes()
        {
            fornecedorValido = Builder<Fornecedor>.CreateNew().Build();

            fornecedoresRepositorio = Substitute.For<IFornecedoresRepositorio>();

            sut = new FornecedoresServico(fornecedoresRepositorio);
        }

        public class ValidarMetodo : FornecedoresServicoTestes
        {
            [Fact]
            public void Quando_FornecedorNaoEncontrado_Espero_Exception()
            {
                fornecedoresRepositorio.Recuperar(Arg.Any<int>()).Returns(x => null);

                sut.Invoking(x => x.Validar(1)).Should().Throw<Exception>();
            }

            [Fact]
            public void Quando_FornecedorEncontrado_Espero_FornecedorValido()
            {
                fornecedoresRepositorio.Recuperar(Arg.Any<int>()).Returns(fornecedorValido);

                sut.Validar(1).Should().BeSameAs(fornecedorValido);
            }
        }

        public class InstanciarMetodo : FornecedoresServicoTestes
        {
            [Fact]
            public void Dado_ParametrosParaCriarFornecedor_Espero_FornecedorInstanciado()
            {
                var fornecedor = sut.Instanciar(
                                    "Nome de um fornecedor",
                                    "578330008",
                                    "48567902000130",
                                    "785955070");

                fornecedor.Should().NotBeNull();
            }
        }

        public class InserirMetodo : FornecedoresServicoTestes
        {
            [Fact]
            public void Dado_FornecedorValido_Espero_FornecedorValido()
            {
                sut.Inserir(fornecedorValido);
                fornecedoresRepositorio.Received(1).Inserir(fornecedorValido);
            }
        }

        public class EditarMetodo : FornecedoresServicoTestes
        {
            [Fact]
            public void Dado_ParametrosParaEditarFornecedor_Espero_FornecedorEditado()
            {
                //Arrange
                fornecedoresRepositorio.Recuperar(Arg.Any<int>()).Returns(fornecedorValido);
                fornecedoresRepositorio.Editar(Arg.Any<Fornecedor>()).Returns(fornecedorValido);
                var fornecedorNovo = new Fornecedor(
                                    "Nome de um fornecedor editado",
                                    "578330008",
                                    "48567902000130",
                                    "785955070");

                //Act 
                var fornecedorEditado = sut.Editar(fornecedorNovo);

                //Assert 
                fornecedorEditado.Nome.Should().Be("Nome de um fornecedor editado");
                fornecedorEditado.RazaoSocial.Should().Be("578330008");
                fornecedorEditado.Cnpj.Should().Be("48567902000130");
                fornecedorEditado.Ie.Should().Be("785955070");
            }
        }
    }
}