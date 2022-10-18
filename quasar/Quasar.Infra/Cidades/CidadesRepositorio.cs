using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.Cidades.Entidades;
using Quasar.Dominio.Cidades.Repositorios;
using Quasar.Infra.Genericos;

namespace Quasar.Infra.Cidades
{
    public class CidadesRepositorio :  GenericosRepositorio<Cidade>, ICidadesRepositorio

    {
        public CidadesRepositorio(ISession session) : base(session) {}
    }
}