using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using NSubstitute;
using Quasar.Dominio.Ufs.Entidades;
using Quasar.Dominio.Ufs.Repositorios;
using Quasar.Dominio.Ufs.Servicos;
using Xunit;

namespace Quasar.Dominio.Testes.Ufs.Servicos
{
    public class UfsServicoTestes
    {
        private readonly UfsServico sut;
        private readonly IUfsRepositorio ufsRepositorio;
        private readonly Uf ufValido;

        public UfsServicoTestes()
        {
            ufValido = Builder<Uf>.CreateNew().Build();
            ufsRepositorio = Substitute.For<IUfsRepositorio>();

            sut = new UfsServico(ufsRepositorio);

        }
        public class ValidarMetodo : UfsServicoTestes
        {
            [Fact]
            public void Quando_UfNaoForEncontrado_Espero_Exception()
            {
                ufsRepositorio.Recuperar(Arg.Any<int>()).Returns(x => null);

                sut.Invoking(x => x.Validar(1)).Should().Throw<Exception>();
            }

            [Fact]
            public void Quando_UfForEncontrado_Espero_ProdutoValido()
            {
                ufsRepositorio.Recuperar(Arg.Any<int>()).Returns(ufValido);
                sut.Validar(1).Should().BeSameAs(ufValido);
            }
        }
    }
}