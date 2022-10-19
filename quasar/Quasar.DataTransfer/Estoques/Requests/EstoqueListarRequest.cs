using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Estoques.Requests
{
    public class EstoqueListarRequest
    {
        public int Codigo {get; set;}
        public int Quantidade {get; set;}
    }
}