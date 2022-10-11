using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.StatusVendas.Entidades;
using Quasar.Dominio.StatusVendas.Repositorios;

namespace Quasar.Infra.StatusVendas
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

        public StatusVenda Recuperar(int cod)
        {
            return session.Get<StatusVenda>(cod);
        }
    }
}