using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.FormasPagamento.Entidades;

namespace Quasar.Dominio.Vendas.Entidades
{
    public class Vendas
    {

        public int Codigo {get; protected set;}
        public StatusVenda StatusVenda {get; protected set;}
        public FormaPagamento FormasPagamento {get; protected set;}
        public Endereco Endereco {get; protected set;}
        public Usuario Usuario {get; protected set;}
        
        public Vendas()
        {
            
        }
        
        public Vendas(int codigo, StatusVenda statusVenda, FormaPagamento formasPagamento, Endereco endereco, Usuario usuario)
        {
            Codigo = codigo;
            StatusVenda = statusVenda;
            FormasPagamento = formasPagamento;
            Endereco = endereco;
            Usuario = usuario;
        }


    }
}