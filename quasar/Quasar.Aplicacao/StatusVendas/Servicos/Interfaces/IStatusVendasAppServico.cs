using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.StatusVendas.Responses;

namespace Quasar.Aplicacao.StatusVendas.Servicos.Interfaces
{
    public interface IStatusVendasAppServico
    {
        StatusVendaResponse Recuperar(int cod);
    }
}