using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.FormasPagamento.Responses;

namespace Quasar.DataTransfer.Vendas.Responses
{
    public class VendaResponse
    {
        public int Codigo { get; set; } 
        public EnderecoResponse Endereco { get; set; }
        public UsuarioResponse Usuario { get; set; }
        public FormaPagamentoResponse FormaPagamento { get; set; }
        public StatusVendaResponse StatusVenda { get; set; }

    }
}