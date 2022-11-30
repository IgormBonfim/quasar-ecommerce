using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Quasar.Dominio.Usuarios.Excecoes
{
    public class UsuarioInvalidoExcecao : Exception
    {
        public UsuarioInvalidoExcecao()
        {
        }

        public UsuarioInvalidoExcecao(string? message) : base(message)
        {
        }

        public UsuarioInvalidoExcecao(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UsuarioInvalidoExcecao(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}