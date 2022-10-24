using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.Categorias.Entidades;
using Quasar.Dominio.Categorias.Repositorios;
using Quasar.Infra.Genericos;

namespace Quasar.Infra.Categorias
{
    public class CategoriasRepositorio : GenericosRepositorio<Categoria>, ICategoriasRepositorio
    {
        public CategoriasRepositorio(ISession session) : base(session){}
    }
}