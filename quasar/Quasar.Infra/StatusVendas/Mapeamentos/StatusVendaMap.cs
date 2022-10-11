using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Quasar.Dominio.StatusVendas.Entidades;

namespace Quasar.Infra.StatusVendas.Mapeamentos
{
    public class StatusVendaMap : ClassMap<StatusVenda>
    {
        public StatusVendaMap()
        {
            Schema("quasarecommerce");
            Table("statusVenda");
            Id(p => p.Codigo).Column("codStatusVenda").GeneratedBy.Identity();
            Map(p => p.Descricao).Column("descricao");
        }
    }
}