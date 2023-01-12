using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Categorias.Entidades;
using Quasar.Dominio.Fornecedores.Entidades;

namespace Quasar.Dominio.Produtos.Entidades
{
    public class Produto
    {
        public virtual int Codigo { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual decimal Valor { get; protected set; }
        public virtual string Imagem { get; protected set; }
        public virtual Categoria Categoria { get; protected set; }
        public virtual Fornecedor Fornecedor { get; protected set; }
        public virtual Especificacao Especificacao { get; protected set; }   
        
        public Produto() { }
        public Produto(string? descricao, string? nome, decimal? valor, string? imagem, Especificacao especificacao, Categoria categoria, Fornecedor fornecedor)
        {
            SetDescricao(descricao);
            SetNome(nome);
            SetValor(valor);
            SetCategoria(categoria);
            SetFornecedor(fornecedor);
            SetEspecificacao(especificacao);
            SetImagem(imagem);
        }

        public virtual void SetCodigo(int? codigo)
        {
            if(!codigo.HasValue)
            {
                throw new Exception("Código do produto é obrigatório!");
            }
            Codigo = codigo.Value;
        }

        public virtual void SetDescricao(string? descricao)
        {
            if(string.IsNullOrWhiteSpace(descricao) || descricao.Length < 20)
                throw new Exception("O campo descrição deve possuir ao menos 20 caracteres!");

            if(descricao.Length > 255)
                throw new Exception("O campo descrição deve possuir até 255 caracteres!");

            Descricao = descricao;
        }

        public virtual void SetNome(string? nome)
        {
            if(string.IsNullOrWhiteSpace(nome) || nome.Length < 10)
                throw new Exception("O campo nome deve possuir ao menos 10 caracteres");

            if(nome.Length > 100)
                throw new Exception("O campo nome deve possuir até 100 caracteres!");
            Nome = nome;
        }
        public virtual void SetValor(decimal? valor)
        {
            if(!valor.HasValue || valor.Value <=0)
                throw new Exception("Valor do produto é obrigatório!");
            Valor = valor.Value;
        }
        public virtual void SetCategoria(Categoria categoria)
        {
            if(categoria == null)
                throw new Exception("O campo categoria é obrigatório.");
            Categoria = categoria;
        }
        public virtual void SetFornecedor(Fornecedor fornecedor)
        {
            if(fornecedor == null)
                throw new Exception("O fornecedor precisa ser informado.");

            Fornecedor = fornecedor;
        }
        public virtual void SetImagem(string? imagem)
        {
            if (string.IsNullOrWhiteSpace(imagem))
                throw new Exception("O campo de URL da imagem do produto é obrigatório");
            Imagem = imagem;
        }
        public virtual void SetEspecificacao(Especificacao? especificacao)
        {
            if (especificacao == null)
                throw new Exception("O campo especificacão é obrigatório!");
            Especificacao = especificacao;
        }
    }
}