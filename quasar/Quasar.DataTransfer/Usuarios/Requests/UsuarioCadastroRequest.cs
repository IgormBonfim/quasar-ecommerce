using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.DataTransfer.Usuarios.Requests
{
    public class UsuarioCadastroRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        [Compare(nameof(Senha), ErrorMessage = "As senhas devem ser iguais")]
        public string SenhaConfirmacao { get; set; }
        public ClienteInserirRequest Cliente { get; set; }
    }
}