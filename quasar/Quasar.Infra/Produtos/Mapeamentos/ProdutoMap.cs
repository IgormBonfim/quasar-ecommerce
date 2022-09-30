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
            Id(p => p.IdProduto).Column("idProduto").GeneratedBy.Identity();
            Map(p => p.DescricaoProduto).Column("descricaoProduto");
            Map(p => p.NomeProduto).Column("nomeProduto");
            Map(p => p.ImgProduto).Column("imgProduto");
            References(p => p.Categoria).Column("idCategoria");
            References(p => p.Fornecedor).Column("idFornecedor");
            
            //References - Relacionamento um para um
            //HasMany - Relacionamento um para N
            //HasManyToMany - Relacionamento N para N
        }
        
    }
}