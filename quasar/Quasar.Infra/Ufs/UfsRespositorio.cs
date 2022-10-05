using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.Ufs.Entidades;
using Quasar.Dominio.Ufs.Repositorios;

namespace Quasar.Infra.Ufs
{
    public class UfsRepositorio : IUfsRepositorio
    {
        private readonly ISession session;
        public UfsRepositorio(ISession session)
        {
            this.session = session;
        }

    public IQueryable<Uf> Query()
    {
    return session.Query<Uf>();
    }

    public Uf Recuperar (int id)
    {
        return session.Get<Uf>(id);
    }
    }
}