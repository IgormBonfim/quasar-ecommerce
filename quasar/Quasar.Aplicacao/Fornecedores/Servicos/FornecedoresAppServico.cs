using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NHibernate;
using Quasar.Aplicacao.Fornecedores.Servicos.Interfaces;
using Quasar.DataTransfer.Fornecedores.Requests;
using Quasar.DataTransfer.Fornecedores.Responses;
using Quasar.Dominio.Fornecedores.Entidades;
using Quasar.Dominio.Fornecedores.Repositorios;
using Quasar.Dominio.Fornecedores.Servicos.Interfaces;

namespace Quasar.Aplicacao.Fornecedores.Servicos
{
    public class FornecedoresAppServico : IFornecedoresAppServico
    {
        private readonly ISession session;
        private readonly IMapper mapper;
        private readonly IFornecedoresServico fornecedoresServico;
        private readonly IFornecedoresRepositorio fornecedoresRepositorio;

        public FornecedoresAppServico(ISession session, IMapper mapper, IFornecedoresServico fornecedoresServico, IFornecedoresRepositorio fornecedoresRepositorio)
        {
            this.session = session;
            this.mapper = mapper;
            this.fornecedoresServico = fornecedoresServico;
            this.fornecedoresRepositorio = fornecedoresRepositorio;
        }
        public IList<FornecedorResponse> Listar(FornecedorListarRequest listarRequest)
        {
            try
            {
                IQueryable<Fornecedor> query = fornecedoresRepositorio.Query();

                if(listarRequest.IdFornecedor != null)
                {
                    query = query.Where(f => f.IdFornecedor == listarRequest.IdFornecedor);
                }

                if(listarRequest.NomeFornecedor != null)
                {
                    query = query.Where(f => f.NomeFornecedor.Contains(listarRequest.NomeFornecedor));
                }

                if(listarRequest.CnpjFornecedor != null)
                {
                    query = query.Where(f => f.CnpjFornecedor.Contains(listarRequest.CnpjFornecedor));
                }

                IList<Fornecedor> listaFornecedores = fornecedoresServico.Listar(query);

                return mapper.Map<IList<FornecedorResponse>>(listaFornecedores);
            }
            catch
            {
                throw;
            }
        }

        public void Deletar(int id)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                fornecedoresServico.Deletar(id);
                if(transacao.IsActive)
                    transacao.Commit();
            }
            catch
            {
                if(transacao.IsActive)
                    transacao.Rollback();
                throw;
            }
        }

        public FornecedorEditarResponse Editar(FornecedorEditarRequest editarRequest)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                Fornecedor fornecedorEditar = fornecedoresServico.Instanciar(editarRequest.NomeFornecedor, editarRequest.RazaoSocialFornecedor, editarRequest.CnpjFornecedor, editarRequest.IeFornecedor);
                Fornecedor fornecedorEditado = fornecedoresServico.Editar(fornecedorEditar);

                if(transacao.IsActive)
                    transacao.Commit();
                return mapper.Map<FornecedorEditarResponse>(editarRequest);
            }
            catch
            {
                if(transacao.IsActive)
                    transacao.Rollback();
                throw;
            }
        }

        public FornecedorInserirResponse Inserir(FornecedorInserirRequest inserirRequest)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                Fornecedor fornecedorInserir = fornecedoresServico.Instanciar(inserirRequest.NomeFornecedor, inserirRequest.RazaoSocialFornecedor, inserirRequest.CnpjFornecedor, inserirRequest.IeFornecedor);
                
                Fornecedor fornecedorInserido = fornecedoresServico.Inserir(fornecedorInserir);

                if(transacao.IsActive)
                    transacao.Commit();
                return mapper.Map<FornecedorInserirResponse>(fornecedorInserir);
            }
            catch
            {
                if(transacao.IsActive)
                    transacao.Rollback();
                throw;
            }
        }

        public FornecedorResponse Recuperar(int id)
        {
            try
            {
                Fornecedor fornecedor = fornecedoresServico.Validar(id);
                return mapper.Map<FornecedorResponse>(fornecedor);
            }
            catch
            {
                throw;
            }
            
        }
    }
}