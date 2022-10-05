using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Fornecedores.Responses
{
    public class FornecedorEditarResponse
    {
        public int IdFornecedor { get; set; }
        public string NomeFornecedor { get; set; }
        public string RazaoSocialFornecedor { get; set; }
        public string CnpjFornecedor { get; set; }
        public string? IeFornecedor { get; set; }
    }
}