using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Quasar.Dominio.Vendas.Entidades;

namespace Quasar.Infra.Vendas.Mapeamentos
{
    public class VendasMap : ClassMap<Venda>
    {
        public VendasMap()
        {
            Schema("quasarecommerce");
            Table("venda");
            Id(p => p.Codigo).Column("codVenda").GeneratedBy.Identity();

            References(p => p.StatusVenda).Column("codStatusVenda");
            References(p => p.FormaPagamento).Column("codFormaPagamento");
            References(p => p.Endereco).Column("codEndereco");
            References(p => p.Usuario).Column("codUsuario");
            HasMany(p => p.Itens).KeyColumn("codVenda").NotFound.Ignore();
            
        }
    }
}