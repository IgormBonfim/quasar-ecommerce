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
        public decimal Valor { get; set; }
        public string Imagem { get; set; }
        public int CodigoCategoria { get; set; }
        public int CodigoFornecedor { get; set; }
        public int QuantidadeEstoque { get; set; }
        public EspecificacaoInserirRequest Especificacao { get; set; }
    }
}