using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Vendas.Request;
using Quasar.DataTransfer.Vendas.Responses;

namespace Quasar.Aplicacao.Vendas.Servicos.Interfaces
{
    public interface IVendasAppServico
    {
        VendaInserirResponse Inserir(VendaInserirRequest inserirResquest);
        VendaEditarResponse Editar (VendaEditarRequest editarRequest);
        VendaResponse Recuperar (int codigo);
    }
}