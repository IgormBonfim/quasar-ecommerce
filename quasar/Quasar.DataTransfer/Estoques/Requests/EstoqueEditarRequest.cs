using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Estoques.Requests
{
    public class EstoqueEditarRequest
    {
        public int Codigo {get; set;}
        public int Quantidade {get; set;}
        public int CodProduto {get; set;}
    }
}