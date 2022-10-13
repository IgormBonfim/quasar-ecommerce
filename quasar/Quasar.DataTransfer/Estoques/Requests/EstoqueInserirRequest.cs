using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Estoques.Requests
{
    public class EstoqueInserirRequest
    {
        public int Quantidade {get; set;}
        public int CodProduto {get; set;}
    }
}