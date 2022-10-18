using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Quasar.Dominio.Produtos.Entidades;

namespace Quasar.Infra.Produtos.Mapeamentos
{
    public class EspecificacaoMap : ClassMap<Especificacao>
    {
        public EspecificacaoMap()
        {
            Schema("quasarecommerce");
            Table("especificacao");
            Id(e => e.Codigo).Column("codEspecificacao").GeneratedBy.Identity();
            Map(e => e.Posicao).Column("posicao");
            Map(e => e.Cor).Column("cor");
            Map(e => e.Ano).Column("ano");
            Map(e => e.Veiculo).Column("veiculo");
        }
    }
}