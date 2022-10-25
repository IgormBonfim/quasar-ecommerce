using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Vendas.Request
{
    public class VendaInserirRequest
    {
        public int CodEndereco {get; set;}
        public int CodFormaPagamento {get; set;}
        public string CodUsuario {get; set;}
        public string CodStatusVenda {get; set;}

        // passar uma lista de codigos de produtos
        // lista de item venda
        
    }
}