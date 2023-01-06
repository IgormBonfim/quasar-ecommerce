using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Genericos.Requests;

namespace Quasar.DataTransfer.Produtos.Requests
{
    public class ProdutoBuscarRequest : PaginacaoRequest
    {
        public int? Codigo { get; set; }
        public string? Nome { get; set; }
        public int? CodCategoria { get; set; }
    }
}
