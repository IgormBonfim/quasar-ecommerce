using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Produtos.Responses
{
    public class ProdutoResponse
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Imagem { get; set; }
        public EspecificacaoResponse EspecificacaoResponse { get; set; }

    }
}