using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Produtos.Responses;

namespace Quasar.DataTransfer.Vendas.Responses
{
    public class ItemVendaResponse
    {
        public int Codigo {get; set;}
        public int Quantidade {get; set;}
        public ProdutoResponse Produto {get; set;}
        public decimal ValorUnitario {get; set;}
    }
}