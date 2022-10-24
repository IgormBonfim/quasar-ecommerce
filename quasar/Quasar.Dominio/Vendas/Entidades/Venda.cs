using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.FormasPagamento.Entidades;

namespace Quasar.Dominio.Vendas.Entidades
{
    public class Venda
    {

        public virtual int Codigo {get; protected set;}
        public virtual StatusVenda StatusVenda {get; protected set;}
        public virtual FormaPagamento FormaPagamento {get; protected set;}
        public virtual Endereco Endereco {get; protected set;}
        public virtual Usuario Usuario {get; protected set;}
        // lista item venda

        
        public Venda()
        {
            
        }
        
        public Venda(int codigo, StatusVenda statusVenda, FormaPagamento formaPagamento)
        {
            Codigo = codigo;
            StatusVenda = statusVenda;
            FormaPagamento = formaPagamento;
            Endereco = endereco;
            Usuario = usuario;
        }

        public virtual void SetCodigo(int? codigo)
        {
            if(!codigo.HasValue)
            {
                throw new Exception("Código da venda é obrigatório!");
            }
            Codigo = codigo.Value;
        }
        public virtual void SetStatusVenda(StatusVenda statusVenda)
        {
            if(statusVenda == null)
            throw new Exception("O status da venda precisa ser informado.");
            StatusVenda = statusVenda;
        }
        public virtual void SetFormaPagamento(FormaPagamento formaPagamento)
        {
            if(formaPagamento == null)
            throw new Exception("A forma de pagamento da venda precisa ser informada.");
            FormaPagamento = formaPagamento;
        }

        public virtual void SetEndereco(Endereco endereco)
        {
            if(endereco == null)
            throw new Exception("O endereço deve ser informado.");
            Endereco = endereco;
        }
        public virtual void SetUsuario(Usuario usuario)
        {
        if(usuario == null)
        throw new Exception("O usuario precisa ser informado");
        Usuario = usuario;
        }
    }
}