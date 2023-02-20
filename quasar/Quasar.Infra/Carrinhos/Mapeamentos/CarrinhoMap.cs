using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Quasar.Dominio.Carrinhos.Entidades;

namespace Quasar.Infra.Carrinhos.Mapeamentos
{
    public class CarrinhoMap : ClassMap<Carrinho>
    {
        public CarrinhoMap() 
        {
            Schema("railway");
            Table("carrinho");
            Id(c => c.Codigo).Column("codCarrinho").GeneratedBy.Identity();
            Map(c => c.Quantidade).Column("quantidade");
            References(c => c.Produto).Column("codProduto");
            References(c => c.Usuario).Column("codUsuario");
        }
    }
}