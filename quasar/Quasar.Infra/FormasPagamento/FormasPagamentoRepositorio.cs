using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.FormasPagamento.Entidades;
using Quasar.Dominio.FormasPagamento.Repositorios;
using Quasar.Infra.Genericos;

namespace Quasar.Infra.FormasPagamento
{
    public class FormasPagamentoRepositorio : GenericosRepositorio<FormaPagamento>, IFormasPagamentoRepositorio{
        public FormasPagamentoRepositorio(ISession session) : base(session) {}
    }
}