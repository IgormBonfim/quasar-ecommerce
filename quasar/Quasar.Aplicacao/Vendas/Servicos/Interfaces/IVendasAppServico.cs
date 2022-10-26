using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Genericos.Responses;
using Quasar.DataTransfer.Vendas.Request;
using Quasar.DataTransfer.Vendas.Responses;
using Quasar.Dominio.Genericos.Entidades;

namespace Quasar.Aplicacao.Vendas.Servicos.Interfaces
{
    public interface IVendasAppServico
    {
        VendaInserirResponse Inserir(VendaInserirRequest inserirResquest);
        VendaEditarResponse Editar (VendaEditarRequest editarRequest);
        VendaResponse Recuperar (int codigo);
        ListaPaginadaResponse<VendaResponse> Listar(VendaListarRequest listarRequest);
    }
}