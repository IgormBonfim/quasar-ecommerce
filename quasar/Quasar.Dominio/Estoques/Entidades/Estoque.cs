using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Produtos.Entidades;

namespace Quasar.Dominio.Estoques.Entidades
{
    public class Estoque
    {
        public virtual int IdEstoque {get; protected set;}
        public virtual int QntEstoque {get; protected set;}
        public virtual Produto Produto {get; protected set;}

        public Estoque ()   {   }

            public Estoque(int idEstoque, int qntEstoque, Produto produto)
        {
            IdEstoque = idEstoque;
            QntEstoque = qntEstoque;
            Produto = produto;
        }

        public virtual void SetIdEstoque(int? idEstoque)
        {
            if(!idEstoque.HasValue)
            throw new Exception("O código do estoque é obirgatório!");
            IdEstoque = idEstoque.Value;
        }

        public virtual void SetQntEstoque(int qntEstoque)
        {
            if(qntEstoque < 0)
            throw new Exception("A quantidade em estoque do produto não pode ser negativo");
            QntEstoque = qntEstoque;
        }

        public virtual void SetProduto(Produto produto)
        {
            if(produto == null)
            throw new Exception("O produto não pode ser nulo.");
            Produto = produto;
        }
    }
}