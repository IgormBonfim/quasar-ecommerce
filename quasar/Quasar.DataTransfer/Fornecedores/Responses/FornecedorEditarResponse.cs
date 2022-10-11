using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Fornecedores.Responses
{
    public class FornecedorEditarResponse
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string? Ie { get; set; }
    }
}