using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.AspNetCore.Identity.Mappings;
using FluentNHibernate.Mapping;
using Quasar.Dominio.Usuarios.Entidades;

namespace Quasar.Infra.Usuarios.Mapeamentos
{
    public class UsuarioMap : IdentityUserMapBase<Usuario, string>
    {
        public UsuarioMap() : base(u => u.Column("Id"))
        {
            Schema("railway");
            Table("Aspnetusers");
            References(u => u.Cliente).Column("CodCliente");
            HasManyToMany(x => x.Favoritos)
            .Table("favorito")
            .ParentKeyColumn("codUsuario")
            .ChildKeyColumn("codProduto")
            .NotFound.Ignore();
        }
    }
}