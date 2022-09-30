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
            Id(u => u.IdUf).Column("idUf").GeneratedBy.Identity();
            Map(u => u.SiglaUf).Column("siglaUf");
            Map(u => u.DescUf).Column("descUf");
        }
    }
}