using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Cidades.Entidades;

namespace Quasar.Dominio.Cidades.Repositorios
{
    public interface ICidadesRepositorio
    {
        Cidade Recuperar(int codigo);
        IQueryable<Cidade> Query();  
    }
}