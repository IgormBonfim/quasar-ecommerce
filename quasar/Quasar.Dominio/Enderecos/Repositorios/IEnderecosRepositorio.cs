using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Enderecos.Entidades;
using Quasar.Dominio.Genericos;

namespace Quasar.Dominio.Enderecos.Repositorios
{
    public interface IEnderecosRepositorio : IGenericosRepositorio<Endereco>{}
}