using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Quasar.Dominio.Produtos.Entidades;

namespace Quasar.Infra.Produtos.Mapeamentos
{
    public class ProdutoMap : ClassMap<Produto>
    {
        public ProdutoMap()
        {
            Schema("quasarecommerce");
            Table("produto");
            Id(p => p.Codigo).Column("codProduto").GeneratedBy.Identity();
            Map(p => p.Descricao).Column("descricao");
            Map(p => p.Nome).Column("nome");
            Map(p => p.Imagem).Column("imagem");
            References(p => p.Categoria).Column("codCategoria");
            References(p => p.Fornecedor).Column("codFornecedor");
            References(p => p.Especificacao).Column("codEspecificacao");
            
            //References - Relacionamento um para um
            //HasMany - Relacionamento um para N
            //HasManyToMany - Relacionamento N para N
        }
        
    }
}