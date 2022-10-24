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

        public IList<T> Listar(IQueryable<T> query, int qt, int pagina)
        {
            int offset = (pagina * qt) - qt;
            IList<T> lista = query.Take(qt).Skip(offset).ToList();

            double totalVideos = query.Count();
            int totalPaginas = (int)Math.Ceiling(totalVideos / qt);

            return new ListaPaginada<T>()
            {
                Pagina = pagina,
                Quantidade = qt,
                TotalPaginas = totalPaginas,
                Lista = lista
            };
        }

        public IQueryable<T> Query()
        {
            return session.Query<T>();
        }

        public T Recuperar(int codigo)
        {
            return session.Get<T>(codigo);
        }
    }
}