using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Categorias.Entidades;
using Quasar.Dominio.Categorias.Repositorios;
using Quasar.Dominio.Categorias.Servicos.Interfaces;

namespace Quasar.Dominio.Categorias.Servicos
{
    public class CategoriasServico : ICategoriasServico
    {
        private readonly ICategoriasRepositorio categoriasRepositorio;

        public CategoriasServico(ICategoriasRepositorio categoriasRepositorio)
        {
            this.categoriasRepositorio = categoriasRepositorio;
        }

        public IList<Categoria> Buscar(IQueryable<Categoria> query)
        {
            return query.ToList();
        }

        public void Deletar(int idCategoria)
        {
            Categoria categoriaDeletar = Validar(idCategoria);
            categoriasRepositorio.Deletar(categoriaDeletar);
        }

        public Categoria Editar(Categoria categoria)
        {
            Categoria categoriaEditar = Validar(categoria.IdCategoria);

            if(categoria.NomeCategoria != categoriaEditar.NomeCategoria);
            categoriaEditar.SetNomeCategoria(categoria.NomeCategoria);

            if(categoria.ImgCategoria != categoriaEditar.ImgCategoria);
            categoriaEditar.SetImgCategoria(categoria.ImgCategoria);

            return categoriasRepositorio.Editar(categoriaEditar);
        }

        public Categoria Inserir(Categoria categoria)
        {
            return categoriasRepositorio.Inserir(categoria);
        }

        public Categoria Instanciar(string nomeCategoria, string imgCategoria)
        {
            Categoria categoria = new Categoria(nomeCategoria, imgCategoria);
            return categoria;
        }

        public Categoria Validar(int id)
        {
            Categoria categoriaValidar = categoriasRepositorio.Recuperar(id);
            if(categoriaValidar == null)
                throw new Exception ("Categoria não encontrado");
            return categoriaValidar;
        }
    }
}