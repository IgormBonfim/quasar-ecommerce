using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.Genericos;

namespace Quasar.Infra.Genericos
{
    public class GenericosRepositorio<T> : IGenericosRepositorio<T> where T : class
    {
        private readonly ISession session;
        
        public GenericosRepositorio(ISession session)
        {
            this.session = session;
        }
        public void Deletar(T objeto)
        {
            session.Delete(objeto);
        }

        public T Editar(T objeto)
        {
            session.Update(objeto);
            return objeto;
        }

        public int Inserir(T objeto)
        {
            int codigo = (int)session.Save(objeto);
            return codigo;
        }

        public IList<T> Listar(IQueryable<T> query)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query()
        {
            return session.Query<T>();
        }

        public T Recuperar(int codigo)
        {
            return session.Get<T>(codigo);
        }

        public T Recuperar(string codigo)
        {
            return session.Get<T>(codigo);
        }
    }
}