using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.StatusVendas.Entidades;

namespace Quasar.Dominio.StatusVendas.Servicos.Interfaces
{
    public interface IStatusVendasServico
    {
        StatusVenda Validar(int cod);
    }
}