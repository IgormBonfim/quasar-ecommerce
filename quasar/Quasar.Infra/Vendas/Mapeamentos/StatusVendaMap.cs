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
            Schema("railway");
            Table("statusVenda");
            Id(p => p.Codigo).Column("codStatusVenda").GeneratedBy.Identity();
            Map(p => p.Descricao).Column("descricao");
        }
    }
}