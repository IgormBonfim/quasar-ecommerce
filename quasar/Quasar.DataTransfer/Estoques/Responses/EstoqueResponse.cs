using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Produtos.Responses;

namespace Quasar.DataTransfer.Estoques.Responses
{
    public class EstoqueResponse
    {
        public int Codigo {get; set;}
        public int Quantidade {get; set;}
        public ProdutoResponse Produto {get; set;}

    }
}