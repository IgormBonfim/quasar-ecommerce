using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Quasar.Dominio.Fornecedores.Entidades;

namespace Quasar.Infra.Fornecedores.Mapeamentos
{
    public class FornecedoresMap : ClassMap<Fornecedor>
    {
        public FornecedoresMap()
        {
            Schema("quasarecommerce");
            Table("fornecedor");
            Id(f => f.IdFornecedor).Column("idFornecedor").GeneratedBy.Identity();
            Map(f => f.NomeFornecedor).Column("nomefornecedor");
            Map(f => f.RazaoSocialFornecedor).Column("razaoSocialFornecedor");
            Map(f => f.CnpjFornecedor).Column("cnpjFornecedor");
            Map(f => f.IeFornecedor).Column("ieFornecedor");
        }
    }
}