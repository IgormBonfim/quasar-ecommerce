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

        public void Deletar(int codigo)
        {
            Categoria categoriaDeletar = Validar(codigo);
            categoriasRepositorio.Deletar(categoriaDeletar);
        }

        public Categoria Editar(Categoria categoria)
        {
            Categoria categoriaEditar = Validar(categoria.Codigo);

            if(categoria.Nome != categoriaEditar.Nome);
            categoriaEditar.SetNome(categoria.Nome);

            if(categoria.Imagem != categoriaEditar.Imagem);
            categoriaEditar.SetImagem(categoria.Imagem);

            return categoriasRepositorio.Editar(categoriaEditar);
        }

        public Categoria Inserir(Categoria categoria)
        {
            int codigo = categoriasRepositorio.Inserir(categoria);
            categoria.SetCodigo(codigo);
            return categoria;
        }

        public Categoria Instanciar(string nome, string imagem)
        {
            Categoria categoria = new Categoria(nome, imagem);
            return categoria;
        }

        public Categoria Validar(int codigo)
        {
            Categoria categoriaValidar = categoriasRepositorio.Recuperar(codigo);
            if(categoriaValidar == null)
                throw new Exception ("Categoria não encontrado");
            return categoriaValidar;
        }
    }
}