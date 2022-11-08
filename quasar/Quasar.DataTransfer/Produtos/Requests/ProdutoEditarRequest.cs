using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Produtos.Requests
{
    public class ProdutoEditarRequest
    {
        [JsonIgnore]
        public int? Codigo { get; set; }
        public string? Descricao { get; set; }
        public string? Nome { get; set; }
        public decimal? Valor { get; set; }
        public string? Imagem { get; set; }
        public int? CodigoCategoria { get; set; }
        public int? CodigoFornecedor { get; set; }
        public EspecificacaoEditarRequest? Especificacao { get; set; }
    }
}