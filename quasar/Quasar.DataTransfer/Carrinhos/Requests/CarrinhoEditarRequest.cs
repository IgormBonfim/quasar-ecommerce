using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Carrinhos.Requests
{
    public class CarrinhoEditarRequest
    {
        public int? Codigo { get; set; }
        public int Quantidade { get; set; }
        public string? CodUsuario { get; set; }
        public int CodProduto { get; set; }
    }
}