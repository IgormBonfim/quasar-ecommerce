using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Usuarios.Responses
{
    public class UsuarioResponse
    {
        public string Codigo { get; set; }
        public string Email { get; set; }
        public ClienteResponse Cliente { get; set; }
    }
}