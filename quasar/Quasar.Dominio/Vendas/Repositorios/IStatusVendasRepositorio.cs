using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Vendas.Entidades;

namespace Quasar.Dominio.Vendas.Repositorios
{
    public interface IStatusVendasRepositorio
    {
        StatusVenda Recuperar(int id);
        IQueryable<StatusVenda> Query();
    }
}