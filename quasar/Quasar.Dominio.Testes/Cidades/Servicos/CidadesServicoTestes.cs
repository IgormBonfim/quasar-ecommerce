using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using NSubstitute;
using Quasar.Dominio.Cidades.Entidades;
using Quasar.Dominio.Cidades.Repositorios;
using Quasar.Dominio.Cidades.Servicos;
using Quasar.Dominio.Ufs.Entidades;
using Quasar.Dominio.Ufs.Servicos.Interfaces;
using Xunit;

namespace Quasar.Dominio.Testes.Cidades.Servicos
{
    public class CidadesServicoTestes
    {
        private readonly CidadesServico sut;
        private readonly ICidadesRepositorio cidadesRepositorio;

        private readonly Cidade cidadeValida;

        public CidadesServicoTestes()
        {
            cidadeValida = Builder<Cidade>.CreateNew().Build();


            cidadesRepositorio = Substitute.For<ICidadesRepositorio>();
   

            sut = new CidadesServico(cidadesRepositorio);
        }

        public class ValidarMetodo : CidadesServicoTestes
        {
            [Fact]
            public void Quando_CidadeNaoForEncontrado_Espero_Exception()
            {
                cidadesRepositorio.Recuperar(Arg.Any<int>()).Returns(x => null);

                sut.Invoking(x => x.Validar(1)).Should().Throw<Exception>();
            }

            [Fact]
            public void Quando_CidadeForEncontrado_Espero_ProdutoValido()
            {
                cidadesRepositorio.Recuperar(Arg.Any<int>()).Returns(cidadeValida);
                sut.Validar(1).Should().BeSameAs(cidadeValida);
            }
        }
    }
}
