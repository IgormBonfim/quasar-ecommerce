using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Vendas.Request
{
    public class VendaEditarRequest
    {   
        public int? Codigo {get; set;}
        public int CodStatusVenda { get; set; }
        public int CodFormaPagamento { get; set; }
        public int CodEndereco { get; set; }
        public string? CodUsuario { get; set; }
        
        
    }
}