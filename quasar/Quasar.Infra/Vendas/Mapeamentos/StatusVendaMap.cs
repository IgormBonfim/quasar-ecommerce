using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Quasar.Dominio.Vendas.Entidades;

namespace Quasar.Infra.Vendas.Mapeamentos
{
    public class StatusVendaMap : ClassMap<StatusVenda>
    {
        public StatusVendaMap()
        {
            Schema("quasarecommerce");
            Table("statusVenda");
            Id(p => p.IdStatusVenda).Column("IdStatusVenda").GeneratedBy.Identity();
            Map(p => p.DescricaoStatusVenda).Column("descricaoStatusVenda");
        }
    }
}