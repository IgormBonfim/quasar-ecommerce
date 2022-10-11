using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NHibernate;
using Quasar.Aplicacao.Vendas.Servicos.Interfaces;
using Quasar.DataTransfer.Vendas.Responses;
using Quasar.Dominio.Vendas.Entidades;
using Quasar.Dominio.Vendas.Servicos.Interfaces;

namespace Quasar.Aplicacao.Vendas.Servicos
{
    public class StatusVendasAppServico : IStatusVendasAppServico
    {
        private readonly ISession session;
        private readonly IStatusVendasServico statusVendasServico;
        private readonly IMapper mapper;

        public StatusVendasAppServico(ISession session, IStatusVendasServico statusVendasServico, IMapper mapper)
        {
            this.session = session;
            this.statusVendasServico = statusVendasServico;
            this.mapper = mapper;
        }
        public StatusVendaResponse Recuperar(int id)
        {
            try
            {
                StatusVenda statusVenda = statusVendasServico.Validar(id);
                return mapper.Map<StatusVendaResponse>(statusVenda);
                
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}