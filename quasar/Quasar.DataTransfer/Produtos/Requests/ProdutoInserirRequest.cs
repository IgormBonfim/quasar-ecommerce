using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Produtos.Requests
{
    public class ProdutoInserirRequest
    {
        public string DescricaoProduto { get; set; }
        public string NomeProduto { get; set; }
        public string ImgPrincipalProduto { get; set; }
        public int IdCategoria { get; set; }
        public int IdFornecedor { get; set; }
        public EspecificacaoInserirRequest Especificacao { get; set; }
    }
}