using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Genericos.Requests;

namespace Quasar.DataTransfer.Vendas.Request
{
    public class VendaListarRequest : PaginacaoRequest
    {
        public int Codigo {get; set;}
        public string? CodUsuario{ get; set;}
        public int CodFormaPagamento {get; set;}
        public int CodEndereco {get; set;}
    }
}