using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NHibernate;
using Quasar.Aplicacao.Usuarios.Servicos.Interfaces;
using Quasar.DataTransfer.Usuarios.Requests;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Produtos.Servicos.Interfaces;
using Quasar.Dominio.Usuarios.Servicos.Interfaces;

namespace Quasar.Aplicacao.Usuarios
{
    public class FavoritosAppServico : IFavoritosAppServico
    {
        private readonly ISession session;
        private readonly IFavoritosServico FavoritosServico;
        private readonly IMapper mapper;
        public FavoritosAppServico (IFavoritosServico favoritoServico, ISession session, IMapper mapper)
        {
            this.session = session;
            this.mapper = mapper;
            this.FavoritosServico = favoritoServico;
        }

        public void Adicionar(FavoritoRequest favoritoRequest)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                FavoritosServico.Adicionar(favoritoRequest.codProduto, favoritoRequest.codUsuario);
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
                FavoritosServico.Remover (favoritoRequest.codProduto, favoritoRequest.codUsuario);
                transacao.Commit();
            }
            catch 
            {
                
                throw;
            }
        }
    }
}