using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.Categorias.Entidades;
using Quasar.Dominio.Categorias.Repositorios;

namespace Quasar.Infra.Categorias
{
    public class CategoriasRepositorio : ICategoriasRepositorio
    {
        private readonly ISession session;

        public CategoriasRepositorio(ISession session)
        {
            this.session = session;
        }

        public void Deletar(Categoria categoria)
        {
            session.Delete(categoria);
        }

        public Categoria Editar(Categoria categoria)
        {
            session.Update(categoria);
            return categoria;
        }

        //não entendi muito bem essa parte
        public Categoria Inserir(Categoria categoria)
        {
            int id = (int)session.Save(categoria);
            categoria.SetIdCategoria(id);
            return categoria;
        }

        public IQueryable<Categoria> Query()
        {
            return session.Query<Categoria>();
        }

        public Categoria Recuperar(int id)
        {
            return session.Get<Categoria>(id);
        }
    }
}