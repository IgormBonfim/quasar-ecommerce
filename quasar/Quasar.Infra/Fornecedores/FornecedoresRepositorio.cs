using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.Fornecedores.Entidades;
using Quasar.Dominio.Fornecedores.Repositorios;
using Quasar.Infra.Genericos;

namespace Quasar.Infra.Fornecedores
{
    public class FornecedoresRepositorio : GenericosRepositorio<Fornecedor>, IFornecedoresRepositorio
    {
        public FornecedoresRepositorio(ISession session) : base(session)
        {}
    }
}