using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Vendas.Request
{
    public class ItemVendaInserirRequest
    {
        public int Quantidade {get; set;}
        public int CodProduto {get; set;}
    }
}