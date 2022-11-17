using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.AspNetCore.Identity.Mappings;
using Quasar.Dominio.Usuarios.Entidades;

namespace Quasar.Infra.Usuarios.Mapeamentos
{
    public class UsuarioRoleMap : IdentityUserRoleMapBase<UsuarioRole, string>
    {
        public UsuarioRoleMap() : base(t => t.KeyProperty(x => x.UserId).KeyProperty(x => x.RoleId))
        {
            Schema("Quasar");
        }
    }
}