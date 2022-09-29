using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.StatusVendas.Entidades;

namespace Quasar.Dominio.StatusVendas.Repositorios
{
    public interface IStatusVendasRepositorio
    {
        StatusVenda Recuperar(int id);
        IQueryable<StatusVenda> Query();
    }
}