using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.StatusVendas.Entidades;
using Quasar.Dominio.StatusVendas.Repositorios;
using Quasar.Infra.Genericos;

namespace Quasar.Infra.StatusVendas
{
    public class StatusVendasRepositorio : GenericosRepositorio<StatusVenda>, IStatusVendasRepositorio
    {
        public StatusVendasRepositorio(ISession session) : base(session)
        {}
    }
}