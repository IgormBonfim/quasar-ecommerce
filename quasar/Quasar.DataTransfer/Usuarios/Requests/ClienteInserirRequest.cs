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
        public string? NomeFantasia { get; set; }
        public string CpfCnpj { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string? RazaoSocial { get; set; }
        public int TipoCliente { get; set; }
    }
}