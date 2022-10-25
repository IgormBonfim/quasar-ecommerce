using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.Vendas.Entidades;
using Quasar.Dominio.Vendas.Repositorios;
using Quasar.Infra.Genericos;

namespace Quasar.Infra.Vendas
{
    public class ItensVendaRepositorio : GenericosRepositorio<ItemVenda>, IItensVendasRepositorio
    {
        public ItensVendaRepositorio(ISession session) : base(session)
        {
        }
    }
}