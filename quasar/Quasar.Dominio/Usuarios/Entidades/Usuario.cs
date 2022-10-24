using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.Dominio.Usuarios.Entidades
{
    public class Usuario
    {
        public virtual string Codigo { get; protected set; }
        public virtual string UserName  { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual Cliente Cliente { get; protected set; }

        public Usuario() { }
    }
}