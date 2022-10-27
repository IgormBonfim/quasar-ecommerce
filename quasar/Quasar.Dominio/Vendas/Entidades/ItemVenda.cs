using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Produtos.Entidades;

namespace Quasar.Dominio.Vendas.Entidades
{
    public class ItemVenda
    {
        public virtual int Codigo {get; protected set;}
        public virtual int Quantidade {get; protected set;}
        public virtual Venda Venda { get; protected set; }
        public virtual Produto Produto {get; protected set;}
        public virtual decimal ValorUnitario {get; protected set;}
        public ItemVenda()
        { 

        }
        public ItemVenda(int? quantidade, Venda? venda, Produto? produto)
        {
            SetQuantidade(quantidade);
            SetVenda(venda);
            SetProduto(produto);
            SetValorUnitario();
        }

        public virtual void SetCodigo(int? codigo)
        {
            if(!codigo.HasValue)
            {
                throw new Exception("O código do item venda é obrigatório.");
            }
            Codigo = codigo.Value;
        }
        public virtual void SetQuantidade(int? quantidade)
        {
        if (!quantidade.HasValue || quantidade.Value <= 0)
                throw new Exception("A quantidade de itens venda não pode ser menor que zero.");
            Quantidade = quantidade.Value;
        }
        public virtual void SetVenda(Venda? venda)
        {
            if(venda == null)
            throw new Exception("A venda precisa ser informada.");
            Venda = venda;
        }
        public virtual void SetProduto(Produto? produto)
        {
            if(produto == null)
                throw new Exception("O produto precisa ser informado.");
            Produto = produto;
        }
        public virtual void SetValorUnitario()
        {
            ValorUnitario = Produto.Valor;
        }
    }
}