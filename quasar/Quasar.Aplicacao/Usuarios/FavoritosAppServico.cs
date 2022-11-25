using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NHibernate;
using Quasar.Aplicacao.Usuarios.Servicos.Interfaces;
using Quasar.DataTransfer.Produtos.Responses;
using Quasar.DataTransfer.Usuarios.Requests;
using Quasar.DataTransfer.Usuarios.Responses;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Produtos.Servicos.Interfaces;
using Quasar.Dominio.Usuarios.Servicos.Interfaces;

namespace Quasar.Aplicacao.Usuarios
{
    public class FavoritosAppServico : IFavoritosAppServico
    {
        private readonly ISession session;
        private readonly IFavoritosServico favoritosServico;
        private readonly IMapper mapper;
        public FavoritosAppServico (IFavoritosServico favoritoServico, ISession session, IMapper mapper)
        {
            this.session = session;
            this.mapper = mapper;
            this.favoritosServico = favoritoServico;
        }

        public void Adicionar(FavoritoRequest favoritoRequest)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                favoritosServico.Adicionar(favoritoRequest.codProduto, favoritoRequest.codUsuario);
                transacao.Commit();
            }   
            catch
            {
                
                throw;
            }
        }

        public void Remover(FavoritoRequest favoritoRequest)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                favoritosServico.Remover (favoritoRequest.codProduto, favoritoRequest.codUsuario);
                transacao.Commit();
            }
            catch 
            {
                
                throw;
            }
        }

        public FavoritoListarResponse Listar(FavoritoListarRequest favoritoListarRequest)
        {
            try
            {
                IList<Produto> listaProduto = favoritosServico.Listar(favoritoListarRequest.codUsuario);

                FavoritoListarResponse response = new FavoritoListarResponse();

                response.Favoritos = mapper.Map<IList<ProdutoResponse>>(listaProduto);

                return response;
            }
            catch 
            {
                throw;
            }
        }
    }
}