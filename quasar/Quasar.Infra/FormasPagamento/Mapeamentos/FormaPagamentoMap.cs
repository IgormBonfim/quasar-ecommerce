using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Quasar.Dominio.FormasPagamento.Entidades;

namespace Quasar.Infra.FormasPagamento.Mapeamentos
{
    public class FormaPagamentoMap : ClassMap<FormaPagamento>
    {
        public FormaPagamentoMap()
        {
            Schema("quasarecommerce");
            Table("formaPagamento");
            Id(f => f.Codigo).Column("codFormaPagamento").GeneratedBy.Identity();
            Map(f => f.Descricao).Column("descricao");
        }
    }
}