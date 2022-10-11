using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Ufs.Entidades;

namespace Quasar.Dominio.Ufs.Repositorios
{
    public interface IUfsRepositorio
    {
        Uf Recuperar (int cod);
        IQueryable<Uf> Query();
    }
}