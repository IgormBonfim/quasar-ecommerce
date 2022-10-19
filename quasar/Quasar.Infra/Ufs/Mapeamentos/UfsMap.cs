using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Quasar.Dominio.Ufs.Entidades;


namespace Quasar.Infra.Ufs.Mapeamentos
{
    public class UfsMap : ClassMap<Uf>
    {
        public UfsMap()
        {
            Schema("quasarecommerce");
            Table("UF");
            Id(u => u.Codigo).Column("codUf").GeneratedBy.Identity();
            Map(u => u.Sigla).Column("sigla");
            Map(u => u.Nome).Column("nome");
        }
    }
}