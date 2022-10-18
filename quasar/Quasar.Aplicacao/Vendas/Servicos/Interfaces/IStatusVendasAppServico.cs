using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Vendas.Responses;

namespace Quasar.Aplicacao.Vendas.Servicos.Interfaces
{
    public interface IStatusVendasAppServico
    {
        StatusVendaResponse Recuperar(int codigo);
    }
}