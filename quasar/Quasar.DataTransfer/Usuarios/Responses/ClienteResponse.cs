using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Usuarios.Responses
{
    public class ClienteResponse
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string? NomeFantasia { get; set; }
        public string? CpfCnpj { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string? RazaoSocial { get; set; }        
    }
}