using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Produtos.Responses;
using Quasar.DataTransfer.Usuarios.Responses;

namespace Quasar.DataTransfer.Carrinhos.Responses
{
    public class CarrinhoResponse
    {
        public int Codigo { get; set; }
        public int Quantidade { get; set; }
        public ProdutoResponse Produto { get; set; }
    }
}