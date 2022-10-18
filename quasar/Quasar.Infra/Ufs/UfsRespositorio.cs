using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.Ufs.Entidades;
using Quasar.Dominio.Ufs.Repositorios;
using Quasar.Infra.Genericos;

namespace Quasar.Infra.Ufs
{
    public class UfsRepositorio : GenericosRepositorio<Uf>, IUfsRepositorio
    {
        public UfsRepositorio(ISession session) : base(session)
        {}
    }
}