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
            Id(c => c.Codigo).Column("codCategoria").GeneratedBy.Identity();
            Map(c => c.Nome).Column("nome");
            Map(c => c.Imagem).Column("imagem");
        }  
    }
}
