using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using NSubstitute;
using Quasar.Dominio.Vendas.Entidades;
using Quasar.Dominio.Vendas.Repositorios;
using Quasar.Dominio.Vendas.Servicos;
using Xunit;

namespace Quasar.Dominio.Testes.StatusVendaServicos.Servicos
{
    public class StatusVendasServicoTestes
    {
        private readonly StatusVendasServico sut;
        private readonly IStatusVendasRepositorio statusVendasRepositorio;
        private readonly StatusVenda statusVendaValido;
    

        public StatusVendasServicoTestes()
        {
            statusVendaValido = Builder<StatusVenda>.CreateNew().Build();
            
            statusVendasRepositorio = Substitute.For<IStatusVendasRepositorio>();

            sut = new StatusVendasServico(statusVendasRepositorio);
        }

        public class ValidarMetodo : StatusVendasServicoTestes
        {
            [Fact]
            public void Quando_StatusVendaNaoEncontrado_Espero_Exception()
            {
                statusVendasRepositorio.Recuperar(Arg.Any<int>()).Returns(x => null);

                sut.Invoking(x => x.Validar(1)).Should().Throw<Exception>();
            }

            [Fact]
            public void Quando_StatusVendaEncontrado_Espero_StatusVendaValido()
            {
                statusVendasRepositorio.Recuperar(Arg.Any<int>()).Returns(statusVendaValido);

                sut.Validar(1).Should().BeSameAs(statusVendaValido);
            }
        }
    }
}