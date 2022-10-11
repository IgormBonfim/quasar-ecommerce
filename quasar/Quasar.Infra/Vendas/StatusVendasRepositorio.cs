using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.Vendas.Entidades;
using Quasar.Dominio.Vendas.Repositorios;

namespace Quasar.Infra.Vendas
{
    public class StatusVendasRepositorio : IStatusVendasRepositorio
    {
        private readonly ISession session;
        public StatusVendasRepositorio(ISession session)
        {
            this.session = session;
        }
        public IQueryable<StatusVenda> Query()
        {
            return session.Query<StatusVenda>();
        }

        public StatusVenda Recuperar(int id)
        {
            return session.Get<StatusVenda>(id);
        }
    }
}