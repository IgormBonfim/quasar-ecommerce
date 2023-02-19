using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Quasar.Dominio.Vendas.Entidades;

namespace Quasar.Infra.Vendas.Mapeamentos
{
    public class ItensVendasMap : ClassMap<ItemVenda>
    {
        public ItensVendasMap()
        {
            Schema("railway");
            Table("itemVenda");
            Id(p => p.Codigo).Column("codItemVenda").GeneratedBy.Identity();
            Map(p => p.Quantidade).Column("quantidade");
            Map(p => p.ValorUnitario).Column("valorUnitario");
            References(p => p.Venda).Column("codVenda");
            References(p => p.Produto).Column("codProduto");
        }
    }
}