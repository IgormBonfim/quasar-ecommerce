using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Produtos.Responses
{
    public class ProdutoResponse
    {
        public int IdProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string NomeProduto { get; set; }
        public string ImgProduto { get; set; }

    }
}