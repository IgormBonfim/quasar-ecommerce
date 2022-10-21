using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.Estoques.Entidades;
using Quasar.Dominio.Estoques.Respositorios;
using Quasar.Infra.Genericos;

namespace Quasar.Infra.Estoques
{
    public class EstoquesRepositorio : GenericosRepositorio<Estoque>, IEstoquesRepositorio
    {
        public EstoquesRepositorio(ISession session) : base(session) {}
    }
}