using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Quasar.Dominio.FormasPagamento.Entidades;

namespace Quasar.Infra.FormasPagamento.Mapeamentos
{
    public class FormasPagamentoMap : ClassMap<FormaPagamento>
    {
        public FormasPagamentoMap()
        {
            Schema("quasarecommerce");
            Table("formaPagamento");
            Id(f => f.IdFormaPagamento).Column("idFormaPagamento").GeneratedBy.Identity();
            Map(f => f.DescricaoFormaPagamento).Column("descricaoFormaPagamento");
        }
    }
}