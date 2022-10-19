using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Estoques.Entidades;
using Quasar.Dominio.Genericos;

namespace Quasar.Dominio.Estoques.Respositorios
{
    public interface IEstoquesRepositorio : IGenericosRepositorio<Estoque>
    {    }
}