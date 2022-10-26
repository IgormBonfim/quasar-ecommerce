using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Quasar.Aplicacao.FormasPagamento.Servicos.Interfaces;
using Quasar.DataTransfer.FormasPagamento.Responses;
using Quasar.DataTransfer.Genericos.Responses;
using Quasar.Dominio.FormasPagamento.Entidades;
using Quasar.Dominio.FormasPagamento.Repositorios;
using Quasar.Dominio.FormasPagamento.Servicos.Interfaces;
using Quasar.Dominio.Genericos.Entidades;

namespace Quasar.Aplicacao.FormasPagamento.Servicos
{
    public class FormasPagamentoAppServico : IFormasPagamentoAppServico
    {
        private readonly IFormasPagamentoServico formasPagamentoServico;
        private readonly IFormasPagamentoRepositorio formasPagamentoRepositorio;
        private readonly IMapper mapper;

        public FormasPagamentoAppServico(IFormasPagamentoServico formasPagamentoServico, IFormasPagamentoRepositorio formasPagamentoRepositorio, IMapper mapper)
        {
            this.formasPagamentoServico = formasPagamentoServico;
            this.formasPagamentoRepositorio = formasPagamentoRepositorio;
            this.mapper = mapper;
        }
        public ListaPaginadaResponse<FormaPagamentoResponse> Listar()
        {
            try
            {
                IQueryable<FormaPagamento> query = formasPagamentoRepositorio.Query();
                ListaPaginada<FormaPagamento> listaFormasPagamento = formasPagamentoRepositorio.Listar(query, 10, 1);
                return mapper.Map<ListaPaginadaResponse<FormaPagamentoResponse>>(listaFormasPagamento);
            }
            catch
            {
                throw;
            }
        }

        public FormaPagamentoResponse Recuperar(int codigo)
        {
            try
            {
                FormaPagamento formaPagamento = formasPagamentoServico.Validar(codigo);
                return mapper.Map<FormaPagamentoResponse>(formaPagamento);
            }
            catch
            {
                throw;
            }

        }
    }
}