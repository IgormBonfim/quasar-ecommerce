using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Quasar.Dominio.Fornecedores.Entidades;

namespace Quasar.Infra.Fornecedores.Mapeamentos
{
    public class FornecedorMap : ClassMap<Fornecedor>
    {
        public FornecedorMap()
        {
            Schema("quasarecommerce");
            Table("fornecedor");
            Id(f => f.Codigo).Column("codFornecedor").GeneratedBy.Identity();
            Map(f => f.Nome).Column("nome");
            Map(f => f.RazaoSocial).Column("razaoSocial");
            Map(f => f.Cnpj).Column("cnpj");
            Map(f => f.Ie).Column("ie");
        }
    }
}