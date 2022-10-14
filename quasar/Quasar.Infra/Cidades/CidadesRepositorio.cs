using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.Cidades.Entidades;
using Quasar.Dominio.Cidades.Repositorios;

namespace Quasar.Infra.Cidades
{
    public class CidadesRepositorio : ICidadesRepositorio

    {
        private readonly ISession session;

        public CidadesRepositorio(ISession session)
        {
            this.session = session;
        }
        public IQueryable<Cidade> Query()
        {
            return session.Query<Cidade>();
        }

        public Cidade Recuperar(int codigo)
        {
            return session.Get<Cidade>(codigo);
        }
    }
}