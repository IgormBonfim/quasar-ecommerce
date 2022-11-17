using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.AspNetCore.Identity.Mappings;
using FluentNHibernate.Mapping;
using Quasar.Dominio.Usuarios.Entidades;

namespace Quasar.Infra.Usuarios.Mapeamentos
{
    public class UsarioMap : IdentityUserMapBase<Usuario, string>
    {
        public UsarioMap() : base(u => u.Column("Id"))
        {
            Schema("quasarecommerce");
            Table("Aspnetusers");
            References(c => c.Cliente).Column("CodCliente");
            HasManyToMany(x => x.Favoritos)
            .Table("favorito")
            .ParentKeyColumn("codUsuario")
            .ChildKeyColumn("codProduto")
            .NotFound.Ignore();
        }
    }
}