using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.AspNetCore.Identity.Mappings;
using Quasar.Dominio.Usuarios.Entidades;

namespace Quasar.Infra.Usuarios.Mapeamentos
{
    public class RoleMap : IdentityRoleMapBase<Role, string>
    {
        public RoleMap() : base(t => t.Column("Id"))
        {
            Schema("railway");
            Table("aspnetroles");
        }
    }
}