using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using NSubstitute;
using Quasar.Dominio.FormasPagamento.Entidades;
using Quasar.Dominio.FormasPagamento.Repositorios;
using Quasar.Dominio.FormasPagamento.Servicos;
using Xunit;

namespace Quasar.Dominio.Testes.FormasPagamento.Servicos
{
    public class FormasPagamentoServicoTestes
    {
        private readonly FormasPagamentoServico sut;
        private readonly IFormasPagamentoRepositorio formasPagamentoRepositorio;

        private readonly FormaPagamento formaPagamentoValida;

        public FormasPagamentoServicoTestes()
        {
            formasPagamentoRepositorio = Substitute.For<IFormasPagamentoRepositorio>();

            sut = new FormasPagamentoServico(formasPagamentoRepositorio);

            formaPagamentoValida = Builder<FormaPagamento>.CreateNew().Build();
        }

        public class ValidarMetodo : FormasPagamentoServicoTestes
        {
            [Fact]
            public void Quando_FormaDePagamentoNaoForEncontrada_Espero_Exception()
            {
                formasPagamentoRepositorio.Recuperar(Arg.Any<int>()).Returns(x => null);

                sut.Invoking(x => x.Validar(1)).Should().Throw<Exception>();
            }

            [Fact]
            public void Quando_FomarDePagamentoForEncontrada_Espero_FormaDePagamentoValida()
            {
                formasPagamentoRepositorio.Recuperar(Arg.Any<int>()).Returns(formaPagamentoValida);

                sut.Validar(1).Should().BeSameAs(formaPagamentoValida);
            }
        }

        public class InstanciarMetodo: FormasPagamentoServicoTestes
        {
            [Fact]
            public void Dado_ParametrosParaCriarFormaPagamento_Espero_FormaPagamentoInstanciada()
            {
                var formaPagamento = sut.Instanciar("Descrição da forma de pagamento");

                formaPagamento.Should().NotBeNull();
            }
        }
    }
}