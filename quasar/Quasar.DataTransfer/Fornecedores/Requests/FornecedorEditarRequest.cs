using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Fornecedores.Requests
{
    public class FornecedorEditarRequest
    {
        [JsonIgnore]
        public int? Codigo { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Ie { get; set; }
    }
}