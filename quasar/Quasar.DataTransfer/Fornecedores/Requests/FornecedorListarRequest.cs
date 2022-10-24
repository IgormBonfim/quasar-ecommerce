using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Genericos.Requests;

namespace Quasar.DataTransfer.Fornecedores.Requests
{
    public class FornecedorListarRequest : PaginacaoRequest
    {
        public int? Codigo { get; set; }
        public string? Nome { get; set; }
        public string? Cnpj { get; set; }
    }
}