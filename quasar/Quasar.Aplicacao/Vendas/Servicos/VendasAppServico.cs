using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NHibernate;
using Quasar.Aplicacao.Vendas.Servicos.Interfaces;
using Quasar.DataTransfer.Vendas.Request;
using Quasar.DataTransfer.Vendas.Responses;
using Quasar.Dominio.Vendas.Entidades;
using Quasar.Dominio.Vendas.Repositorios;
using Quasar.Dominio.Vendas.Servicos.Interfaces;

namespace Quasar.Aplicacao.Vendas.Servicos
{
    public class VendasAppServico : IVendasAppServico
    {
        private readonly ISession session;
        private readonly IVendasServico vendasServico;
        private readonly IVendasRepositorio vendasRepositorio;
        private readonly IMapper mapper;

        public VendasAppServico(ISession session, IVendasServico vendasServico, IVendasRepositorio vendasRepositorio, IMapper mapper)
        {
            this.session = session;
            this.vendasServico = vendasServico;
            this.vendasRepositorio = vendasRepositorio;
            this.mapper = mapper;
        }
        public VendaInserirResponse Inserir(VendaInserirRequest inserirRequest)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                Venda vendaInserir = vendasServico.Instanciar(inserirRequest.CodStatusVenda, inserirRequest.CodEndereco, inserirRequest.CodFormaPagamento, inserirRequest.CodUsuario);
                Venda vendaSalvo = vendasServico.Inserir(vendaInserir);
                if(transacao.IsActive)
                    transacao.Commit();
                return mapper.Map<VendaInserirResponse>(vendaSalvo);
                
            }
            catch
            {
                if(transacao.IsActive)
                transacao.Rollback();
                throw;
            }
        }
        public VendaEditarResponse Editar (VendaEditarRequest editarRequest)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                // Venda vendaEditar = vendasServico.Instanciar(editarRequest.CodStatusVenda);
                // vendaEditar.SetCodigo(editarRequest.Codigo);

                // Venda vendaSalvo = vendasServico.Editar(vendaEditar);
                if(transacao.IsActive)
                    transacao.Commit();
                return mapper.Map<VendaEditarResponse>(Editar); //trocar parametro
            }
            catch
            {
                if(transacao.IsActive)
                    transacao.Rollback();
                    throw;
            }
        }
        public VendaResponse Recuperar(int codigo)
        {
            try
            {
                Venda venda = vendasServico.Validar(codigo);
                return mapper.Map<VendaResponse>(venda);
            }
            catch
            {
                throw;
            }
        }    
    }
}