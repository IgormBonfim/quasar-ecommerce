using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.FormasPagamento.Responses;
using Quasar.DataTransfer.Genericos.Responses;

namespace Quasar.Aplicacao.FormasPagamento.Servicos.Interfaces
{
    public interface IFormasPagamentoAppServico
    {
        FormaPagamentoResponse Recuperar(int codigo);
        ListaPaginadaResponse<FormaPagamentoResponse> Listar();
    }
}