using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.Usuarios.Entidades;
using Quasar.Dominio.Usuarios.Repositorios;
using Quasar.Infra.Genericos;

namespace Quasar.Infra.Usuarios
{
    public class UsuariosRepositorio : GenericosRepositorio<Usuario>, IUsuariosRepositorio
    {
        private readonly ISession session;

        public UsuariosRepositorio(ISession session) : base(session)
        {
            this.session = session;
        }
        public Usuario Recuperar(string codigo)
        {
            return session.Get<Usuario>(codigo);
        }
    }
}