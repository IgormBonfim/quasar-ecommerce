using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Usuarios.Requests
{
    public class UsuarioLoginRequest
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}