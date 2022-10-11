using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Vendas.Entidades;

namespace Quasar.Dominio.Vendas.Servicos.Interfaces
{
    public interface IStatusVendasServico
    {
        StatusVenda Validar(int id);
    }
}