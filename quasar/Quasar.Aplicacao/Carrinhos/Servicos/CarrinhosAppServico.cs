using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NHibernate;
using Quasar.Aplicacao.Carrinhos.Servicos.Interfaces;
using Quasar.DataTransfer.Carrinhos.Requests;
using Quasar.DataTransfer.Carrinhos.Responses;
using Quasar.DataTransfer.Genericos.Responses;
using Quasar.Dominio.Carrinhos.Entidades;
using Quasar.Dominio.Carrinhos.Repositorios;
using Quasar.Dominio.Carrinhos.Servicos.Interfaces;
using Quasar.Dominio.Genericos.Entidades;

namespace Quasar.Aplicacao.Carrinhos.Servicos
{
    public class CarrinhosAppServico : ICarrinhosAppServico
    {
        private readonly ISession session;
        private readonly IMapper mapper;
        private readonly ICarrinhosServico carrinhosServico;
        private readonly ICarrinhosRepositorio carrinhosRepositorio;

        public CarrinhosAppServico(ISession session, IMapper mapper, ICarrinhosServico carrinhosServico, ICarrinhosRepositorio carrinhosRepositorio)
        {
            this.session = session;
            this.mapper = mapper;
            this.carrinhosServico = carrinhosServico;
            this.carrinhosRepositorio = carrinhosRepositorio;
        }
        public void Deletar(int codigo)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                carrinhosServico.Deletar(codigo);
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

        public void Editar(CarrinhoEditarRequest editarRequest)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                Carrinho carrinhoEditar = carrinhosServico.Instanciar(editarRequest.Quantidade, editarRequest.CodProduto, editarRequest.CodUsuario);

                carrinhoEditar.SetCodigo(editarRequest.Codigo);

                Carrinho carrinhoEditado = carrinhosServico.Editar(carrinhoEditar, editarRequest.CodEstoque); 

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

        public void Inserir(CarrinhoInserirRequest carrinhoInserirRequest)
        {
            ITransaction transacao = session.BeginTransaction(); 

            try
            {

                Carrinho carrinhoInserir = carrinhosServico.Instanciar(carrinhoInserirRequest.Quantidade, carrinhoInserirRequest.CodProduto, carrinhoInserirRequest.CodUsuario);

                Carrinho carrinhoSalvo = carrinhosServico.Inserir(carrinhoInserir);

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

        ListaPaginadaResponse<CarrinhoResponse> ICarrinhosAppServico.Listar(CarrinhoListarRequest carrinhoListarRequest)
        {
            var query = carrinhosRepositorio.Query();

            if (carrinhoListarRequest.CodUsuario != null)
            {
                query = query.Where(x => x.Usuario.Codigo == carrinhoListarRequest.CodUsuario);
            }

            ListaPaginada<Carrinho> carrinhos = carrinhosRepositorio.Listar(query, carrinhoListarRequest.
            Quantidade, carrinhoListarRequest.Pagina);

            return mapper.Map<ListaPaginadaResponse<CarrinhoResponse>>(carrinhos);
        }
    }
}