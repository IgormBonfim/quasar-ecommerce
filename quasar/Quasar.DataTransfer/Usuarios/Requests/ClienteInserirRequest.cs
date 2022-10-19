using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Usuarios.Requests
{
    public class ClienteInserirRequest
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CpfCnpj { get; set; }
    }
}