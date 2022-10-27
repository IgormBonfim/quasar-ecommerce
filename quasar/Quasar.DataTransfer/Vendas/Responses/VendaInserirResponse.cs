using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Enderecos.Responses;
using Quasar.DataTransfer.FormasPagamento.Responses;

namespace Quasar.DataTransfer.Vendas.Responses
{
    public class VendaInserirResponse
    {
        public EnderecoResponse Endereco { get; set; }
        public FormaPagamentoResponse FormaPagamento { get; set; }
    }
}