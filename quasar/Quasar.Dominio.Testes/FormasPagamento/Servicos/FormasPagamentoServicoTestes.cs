using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
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
    }
}