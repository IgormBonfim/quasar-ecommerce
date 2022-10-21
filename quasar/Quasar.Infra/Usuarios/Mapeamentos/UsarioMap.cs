using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Quasar.Dominio.Usuarios.Entidades;

namespace Quasar.Infra.Usuarios.Mapeamentos
{
    public class UsarioMap : ClassMap<Usuario>
    {
        public UsarioMap()
        {
            Schema("quasarecommerce");
            Table("Aspnetusers");
            Id(c => c.Codigo).Column("Id");
            Map(c => c.Email).Column("Email");
            Map(c => c.UserName).Column("UserName");
            References(c => c.Cliente).Column("CodCliente");
        }
    }
}