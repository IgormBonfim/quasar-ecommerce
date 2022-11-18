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
            public void Quando_FornecedorEncontrado_Espero_Exception()
            {
                fornecedoresRepositorio.Recuperar(Arg.Any<int>()).Returns(fornecedorValido);

                sut.Validar(1).Should().BeSameAs(fornecedorValido);
            }
        }
    }
}