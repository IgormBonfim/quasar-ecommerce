using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Produtos.Entidades;

namespace Quasar.Dominio.Estoques.Entidades
{
    public class Estoque
    {
        public virtual int Codigo {get; protected set;}
        public virtual int Quantidade {get; protected set;}
        public virtual Produto Produto {get; protected set;}

        public Estoque ()   
        {  

        }
        public Estoque(int quantidade, Produto produto)
        {
            SetQuantidade(quantidade);
            SetProduto(produto);
        }

        public virtual void SetCodigo(int? codigo)
        {
            if(!codigo.HasValue)
            throw new Exception("O código do estoque é obirgatório!");
            Codigo = codigo.Value;
        }

        public virtual void SetQuantidade(int? quantidade)
        {
            if(!quantidade.HasValue || quantidade < 0 )
            throw new Exception("A quantidade em estoque do produto não pode ser negativo");
            Quantidade = quantidade.Value;
        }

        public virtual void SetProduto(Produto produto)
        {
            if(produto == null)
            throw new Exception("O produto não pode ser nulo.");
            Produto = produto;
        }
    }
}