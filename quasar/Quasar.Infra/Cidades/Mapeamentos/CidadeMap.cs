using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Quasar.Dominio.Cidades.Entidades;

namespace Quasar.Infra.Cidades.Mapeamentos
{
    public class CidadeMap : ClassMap<Cidade>
    {
        public CidadeMap()
        {
            Schema("railway");
            Table("cidade");
            Id(p => p.Codigo).Column("codCidade").GeneratedBy.Identity();
            Map(p => p.Nome).Column("Nome");
            References(p => p.Uf).Column("codUf");
        }
    }
}