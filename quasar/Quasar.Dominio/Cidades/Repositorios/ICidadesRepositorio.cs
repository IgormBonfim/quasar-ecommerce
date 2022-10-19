using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Cidades.Entidades;
using Quasar.Dominio.Genericos;

namespace Quasar.Dominio.Cidades.Repositorios
{
    public interface ICidadesRepositorio : IGenericosRepositorio<Cidade> {}
}