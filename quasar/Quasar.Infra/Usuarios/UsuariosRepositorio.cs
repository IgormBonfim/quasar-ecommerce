using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NHibernate;
using Quasar.Dominio.Usuarios.Entidades;
using Quasar.Dominio.Usuarios.Repositorios;
using Quasar.Infra.Genericos;

namespace Quasar.Infra.Usuarios
{
    public class UsuariosRepositorio : GenericosRepositorio<Usuario>, IUsuariosRepositorio
    {
        private readonly ISession session;
        private readonly UserManager<Usuario> userManager;

        public UsuariosRepositorio(ISession session, UserManager<Usuario> userManager) : base(session)
        {
            this.userManager = userManager;
            this.session = session;
        }

        public async Task<IdentityResult> Inserir(Usuario usuario, string senha)
        {
            return await userManager.CreateAsync(usuario, senha);
        }

        public Usuario Recuperar(string codigo)
        {
            return session.Get<Usuario>(codigo);
        }
    }
}