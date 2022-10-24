using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Vendas.Request
{
    public class VendaListarRequest
    {
        public int Codigo {get; set;}
        public int CodUsuario{ get; set;}
        public int CodFormaPagamento {get; set;}
        public int CodEndereco {get; set;}

        // item venda 
    }
}