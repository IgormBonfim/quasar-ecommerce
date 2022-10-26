using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NHibernate;
using Quasar.Aplicacao.Categorias.Servicos.Interfaces;
using Quasar.DataTransfer.Categorias.Requests;
using Quasar.DataTransfer.Categorias.Responses;
using Quasar.DataTransfer.Genericos.Responses;
using Quasar.Dominio.Categorias.Entidades;
using Quasar.Dominio.Categorias.Repositorios;
using Quasar.Dominio.Categorias.Servicos.Interfaces;
using Quasar.Dominio.Genericos.Entidades;

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
                Categoria categoriaInserir = categoriasServico.Instanciar(inserirResquest.Nome, inserirResquest.Imagem);
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
                Categoria categoriaEditar = categoriasServico.Instanciar(editarRequest.Nome, editarRequest.Imagem);
                categoriaEditar.SetCodigo(editarRequest.Codigo);

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

        public CategoriaResponse Recuperar(int codigo)
        {
            try
            {
                Categoria categoria = categoriasServico.Validar(codigo);
                return mapper.Map<CategoriaResponse>(categoria);
            }
            catch
            {
                throw;
            }
        }

        public ListaPaginadaResponse<CategoriaResponse> Buscar(CategoriaBuscarRequest buscarRequest)
        {
            try
            {
                IQueryable<Categoria> query = categoriasRepositorio.Query();

                if (buscarRequest.Codigo != null)
                    query = query.Where(c => c.Codigo == buscarRequest.Codigo);

                if (buscarRequest.Nome != null)
                    query = query.Where(c => c.Nome.Contains(buscarRequest.Nome));

                ListaPaginada<Categoria> listaCategorias = categoriasRepositorio.Listar(query, buscarRequest.Quantidade, buscarRequest.Pagina);

                return mapper.Map<ListaPaginadaResponse<CategoriaResponse>>(listaCategorias);
            }
            catch
            {
                throw;
            }
        }

        public void Deletar(int codigo)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                categoriasServico.Deletar(codigo);
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