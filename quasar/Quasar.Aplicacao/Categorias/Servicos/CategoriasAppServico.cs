using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NHibernate;
using Quasar.Aplicacao.Categorias.Servicos.Interfaces;
using Quasar.DataTransfer.Categorias.Requests;
using Quasar.DataTransfer.Categorias.Responses;
using Quasar.Dominio.Categorias.Entidades;
using Quasar.Dominio.Categorias.Repositorios;
using Quasar.Dominio.Categorias.Servicos.Interfaces;

namespace Quasar.Aplicacao.Categorias.Servicos
{
    public class CategoriasAppServico : ICategoriasAppServico
    {
        private readonly ISession session;
        private readonly ICategoriasServico categoriasServico;
        private readonly ICategoriasRepositorio categoriasRepositorio;
        private readonly IMapper mapper; 

        public CategoriasAppServico(ISession session, ICategoriasServico categoriasServico, ICategoriasRepositorio categoriasRepositorio, IMapper mapper)
        {
            this.session = session;
            this.categoriasServico = categoriasServico;
            this.categoriasRepositorio = categoriasRepositorio;
            this.mapper = mapper;
        }
        public CategoriaInserirResponse Inserir(CategoriaInserirRequest inserirResquest)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                Categoria categoriaInserir = categoriasServico.Instanciar(inserirResquest.NomeCategoria, inserirResquest.ImgCategoria);
                Categoria categoriaSalvo = categoriasServico.Inserir(categoriaInserir);
                if(transacao.IsActive)
                    transacao.Commit();
                return mapper.Map<CategoriaInserirResponse>(categoriaSalvo);
            }
            catch
            {
                if(transacao.IsActive)
                transacao.Rollback();
                throw;
            }
        }
        public CategoriaEditarResponse Editar (CategoriaEditarRequest editarRequest)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                Categoria categoriaEditar = categoriasServico.Instanciar(editarRequest.NomeCategoria, editarRequest.ImgCategoria);
                categoriaEditar.SetIdCategoria(editarRequest.IdCategoria);

                Categoria categoriaSalvo = categoriasServico.Editar(categoriaEditar);
                if(transacao.IsActive)
                    transacao.Commit();
                return mapper.Map<CategoriaEditarResponse>(categoriaSalvo);
            }
            catch
            {
                if(transacao.IsActive)
                    transacao.Rollback();
                    throw;
            }
        }

        public CategoriaResponse Recuperar(int id)
        {
            try
            {
                Categoria categoria = categoriasServico.Validar(id);
                return mapper.Map<CategoriaResponse>(categoria);
            }
            catch
            {
                throw;
            }
        }

        public IList<CategoriaResponse> Buscar(CategoriaBuscarRequest buscarRequest)
        {
            try
            {
                IQueryable<Categoria> query = categoriasRepositorio.Query();

                if (buscarRequest.IdCategoria != null)
                    query = query.Where(c => c.IdCategoria == buscarRequest.IdCategoria);

                if (buscarRequest.NomeCategoria != null)
                    query = query.Where(c => c.NomeCategoria.Contains(buscarRequest.NomeCategoria));

                IList<Categoria> listaCategorias = categoriasServico.Buscar(query);

                return mapper.Map<IList<CategoriaResponse>>(listaCategorias);
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
                categoriasServico.Deletar(id);
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
    }
}