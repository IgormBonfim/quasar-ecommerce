using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NHibernate;
using Quasar.Aplicacao.Estoques.Servicos.Interfaces;
using Quasar.DataTransfer.Estoques.Requests;
using Quasar.DataTransfer.Estoques.Responses;
using Quasar.Dominio.Estoques.Entidades;
using Quasar.Dominio.Estoques.Servicos;
using Quasar.Dominio.Estoques.Servicos.Interfaces;

namespace Quasar.Aplicacao.Estoques.Servicos
{
    public class EstoquesAppServico : IEstoquesAppServico
    {
        private readonly ISession session;
        private readonly IEstoquesServico estoquesServico;
        private readonly IMapper mapper;
        public EstoquesAppServico(ISession session, IEstoquesServico estoquesServico, IMapper mapper)
        {
            this.session = session;
            this.estoquesServico = estoquesServico;
            this.mapper = mapper;
        }

        public EstoqueEditarResponse Editar(EstoqueEditarRequest editarRequest)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                Estoque estoqueEditar = estoquesServico.Instanciar(editarRequest.Quantidade, editarRequest.CodProduto);
                estoqueEditar.SetCodigo(editarRequest.Codigo);
                Estoque estoqueEditado = estoquesServico.Editar(estoqueEditar);

                if (transacao.IsActive)
                    transacao.Commit();
                return mapper.Map<EstoqueEditarResponse>(estoqueEditado);
            }
            catch
            {
                if (transacao.IsActive)
                    transacao.Rollback();
                throw;
            }
        }

        public EstoqueInserirResponse Inserir(EstoqueInserirRequest inserirRequest)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                Estoque EstoqueInserir = estoquesServico.Instanciar(inserirRequest.Quantidade, inserirRequest.CodProduto);
                Estoque EstoqueSalvo = estoquesServico.Inserir(EstoqueInserir);

                if (transacao.IsActive)
                    transacao.Commit();

                return mapper.Map<EstoqueInserirResponse>(EstoqueSalvo);
            }
            catch
            {
                if (transacao.IsActive)
                    transacao.Rollback();
                throw;
            }
        }

        public EstoqueResponse Recuperar(int codigo)
        {
            try
            {
                Estoque estoque = estoquesServico.Validar(codigo);
                return mapper.Map<EstoqueResponse>(estoque);
            }
            catch
            {
                throw;
            }
        }
        public EstoqueResponse RecuperarEstoquePeloCodProduto(int codProduto)
        {
            try
            {
                Estoque estoque = estoquesServico.RetornarEstoquePeloProduto(codProduto);
                return mapper.Map<EstoqueResponse>(estoque);
            }
            catch
            {
                throw;
            }
        }
    }
}
