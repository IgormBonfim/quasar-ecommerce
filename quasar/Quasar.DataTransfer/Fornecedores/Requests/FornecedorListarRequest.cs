using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Fornecedores.Requests
{
    public class FornecedorListarRequest
    {
        public int? Codigo { get; set; }
        public string? Nome { get; set; }
        public string? Cnpj { get; set; }
    }
}