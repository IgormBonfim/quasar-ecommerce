using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Quasar.Aplicacao.FormasPagamento.Servicos.Interfaces;
using Quasar.DataTransfer.FormasPagamento.Responses;
using Quasar.Dominio.FormasPagamento.Entidades;
using Quasar.Dominio.FormasPagamento.Repositorios;
using Quasar.Dominio.FormasPagamento.Servicos.Interfaces;

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
        public IList<FormaPagamentoResponse> Listar()
        {
            try
            {
                IQueryable<FormaPagamento> query = formasPagamentoRepositorio.Query();
                IList<FormaPagamento> listaFormasPagamento = formasPagamentoServico.Query(query);
                return mapper.Map<IList<FormaPagamentoResponse>>(listaFormasPagamento);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public FormaPagamentoResponse Recuperar(int id)
        {
            try
            {
                FormaPagamento formaPagamento = formasPagamentoServico.Validar(id);
                return mapper.Map<FormaPagamentoResponse>(formaPagamento);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}