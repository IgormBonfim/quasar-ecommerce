using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Produtos.Requests
{
    public class ProdutoInserirRequest
    {
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public int CodCategoria { get; set; }
        public int CodFornecedor { get; set; }
    }
}