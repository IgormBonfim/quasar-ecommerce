using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Quasar.Dominio.Usuarios.Excecoes
{
    public class LoginInvalidoExcecao : Exception
    {
        public LoginInvalidoExcecao()
        {
        }

        public LoginInvalidoExcecao(string? message) : base(message)
        {
        }

        public LoginInvalidoExcecao(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected LoginInvalidoExcecao(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}