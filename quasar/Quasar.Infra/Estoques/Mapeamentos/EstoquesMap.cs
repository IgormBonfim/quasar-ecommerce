using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Quasar.Dominio.Estoques.Entidades;

namespace Quasar.Infra.Estoques.Mapeamentos
{
    public class EstoquesMap : ClassMap<Estoque>
    {
        public EstoquesMap()
        {
            Schema("quasarecommerce");
            Table("estoque");
            Id(p => p.Codigo).Column("codEstoque").GeneratedBy.Identity();
            Map(p => p.Quantidade).Column("quantidade");

            References(p => p.Produto).Column("codProduto");
        }
    }
}