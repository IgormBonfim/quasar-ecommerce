using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.FormasPagamento.Entidades;
using Quasar.Dominio.FormasPagamento.Repositorios;

namespace Quasar.Infra.FormasPagamento
{
    public class FormasPagamentoRepositorio : IFormasPagamentoRepositorio
    {
        private readonly ISession session;

        public FormasPagamentoRepositorio(ISession session)
        {
            this.session = session;
        }
        public FormaPagamento Recuperar(int id)
        {
            return session.Get<FormaPagamento>(id);
        }
    }
}