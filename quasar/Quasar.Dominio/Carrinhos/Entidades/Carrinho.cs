using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Usuarios.Entidades;

namespace Quasar.Dominio.Carrinhos.Entidades
{
    public class Carrinho
    {
        public virtual int Codigo { get; protected set; }
        public virtual int Quantidade { get; protected set; }
        public virtual Produto Produto { get; protected set; }
        public virtual Usuario Usuario { get; protected set; } 
        public Carrinho() {}
        public Carrinho(int codigo, int quantidade, Produto produto, Usuario usuario)
        {
            SetCodigo(codigo);
            SetQuantidade(quantidade);
            SetProduto(produto);
            SetUsuario(usuario);
        }
        public virtual void SetCodigo(int? codigo)
        {
            if(!codigo.HasValue)
                throw new Exception("O código não pode ser nulo.");
            Codigo = codigo.Value;
        }
        public virtual void SetQuantidade(int? quantidade)
        {
            if(quantidade < 1 || !quantidade.HasValue)
                throw new Exception("A quantidade deve ser maior que zero.");
            Quantidade = quantidade.Value;
        }

        public virtual void SetProduto(Produto produto)
        {
            Produto = produto;
        }

        public virtual void SetUsuario(Usuario usuario)
        {
            Usuario = usuario;
        }
    }
}