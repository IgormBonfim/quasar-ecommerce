using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NHibernate;
using Quasar.Aplicacao.Vendas.Servicos.Interfaces;
using Quasar.DataTransfer.Genericos.Responses;
using Quasar.DataTransfer.Vendas.Request;
using Quasar.DataTransfer.Vendas.Responses;
using Quasar.Dominio.Genericos.Entidades;
using Quasar.Dominio.Vendas.Entidades;
using Quasar.Dominio.Vendas.Repositorios;
using Quasar.Dominio.Vendas.Servicos.Interfaces;

namespace Quasar.Aplicacao.Vendas.Servicos
{
    public class VendasAppServico : IVendasAppServico
    {
        private readonly ISession session;
        private readonly IVendasServico vendasServico;
        private readonly IItensVendasServico itensVendasServico;
        private readonly IVendasRepositorio vendasRepositorio;
        private readonly IMapper mapper;

        public VendasAppServico(
            ISession session,
            IVendasServico vendasServico,
            IItensVendasServico itensVendasServico,
            IVendasRepositorio vendasRepositorio,
            IMapper mapper)
        {
            this.session = session;
            this.vendasServico = vendasServico;
            this.itensVendasServico = itensVendasServico;
            this.vendasRepositorio = vendasRepositorio;
            this.mapper = mapper;
        }
        public VendaInserirResponse Inserir(VendaInserirRequest inserirRequest)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                Venda vendaInserir = vendasServico.Instanciar(inserirRequest.CodStatusVenda, inserirRequest.CodFormaPagamento, inserirRequest.CodEndereco, inserirRequest.CodUsuario);
                Venda vendaSalvo = vendasServico.Inserir(vendaInserir);

                foreach(var item in inserirRequest.Itens)
                {
                    var itemVenda = itensVendasServico.Instanciar(item.Quantidade, vendaSalvo.Codigo, item.CodProduto);
                    itensVendasServico.Inserir(itemVenda);
                }

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
                Venda vendaSalvo = vendasServico.Editar(editarRequest.Codigo.Value, editarRequest.CodStatusVenda);
                if(transacao.IsActive)
                    transacao.Commit();
                return mapper.Map<VendaEditarResponse>(vendaSalvo);
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

        public ListaPaginadaResponse<VendaResponse> Listar(VendaListarRequest listarRequest)
        {
          try
          {  
            IQueryable<Venda> query = vendasRepositorio.Query();

            if (listarRequest.CodUsuario != null)
                {
                    query = query.Where(f => f.Usuario.Id == listarRequest.CodUsuario);
                }
            ListaPaginada<Venda> listaVenda = vendasRepositorio.Listar(query, listarRequest.Quantidade, listarRequest.Pagina);
            return mapper.Map<ListaPaginadaResponse<VendaResponse>>(listaVenda);
          }
          catch
          {
            throw;
          }
        }
    }
}