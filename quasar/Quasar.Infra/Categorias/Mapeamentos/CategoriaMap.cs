using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Quasar.Dominio.Categorias.Entidades;

namespace Quasar.Infra.Categorias.Mapeamentos
{
    public class CategoriaMap : ClassMap<Categoria>
    {
      public CategoriaMap()
        {
            Schema("quasarecommerce");
            Table("categoria");
            Id(c => c.IdCategoria).Column("idCategoria").GeneratedBy.Identity();
            Map(c => c.NomeCategoria).Column("nomeCategoria");
            Map(c => c.ImgCategoria).Column("imgCategoria");
        }  
    }
}
