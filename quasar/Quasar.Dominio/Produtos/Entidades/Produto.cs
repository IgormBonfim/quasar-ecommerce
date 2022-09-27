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
        public virtual int IdProduto { get; protected set; }
        public virtual string DescricaoProduto { get; protected set; }
        public virtual string NomeProduto { get; protected set; }
        public virtual Categoria Categoria { get; protected set; }
        public virtual Fornecedor Fornecedor { get; protected set; }
        public virtual string ImgPrincipalProduto { get; protected set; }
        public virtual string? ImgSegundaProduto { get; protected set; }
        public virtual string? ImgTerceiraProduto { get; protected set; }
        
        public Produto() { }
        public Produto(string? descricaoProduto, string? nomeProduto, Categoria? categoria, Fornecedor? fornecedor, string? imgPrincipalProduto)
        {
            SetDescricaoProduto(descricaoProduto);
            SetNomeProduto(nomeProduto);
            SetCategoria(categoria);
            SetFornecedor(fornecedor);
            SetImgPrincipalProduto(imgPrincipalProduto);
        }

        public virtual void SetIdProduto(int? idProduto)
        {
            if(!idProduto.HasValue)
            {
                throw new Exception("Código do produto é obrigatório!");
            }
            IdProduto = idProduto.Value;
        }

        public virtual void SetDescricaoProduto(string? descricaoProduto)
        {
            if(string.IsNullOrWhiteSpace(descricaoProduto) && descricaoProduto.Length < 20)
                throw new Exception("O campo descrição deve possuir ao menos 20 caracteres!");

            if(descricaoProduto.Length > 255)
                throw new Exception("O campo descrição deve possuir até 255 caracteres!");

            DescricaoProduto = descricaoProduto;
        }

        public virtual void SetNomeProduto(string? nomeProduto)
        {
            if(string.IsNullOrWhiteSpace(nomeProduto) && nomeProduto.Length < 10)
                throw new Exception("O campo nome deve possuir ao menos 10 caracteres");

            if(nomeProduto.Length > 100)
                throw new Exception("O campo nome deve possuir até 100 caracteres!");
        }
        public virtual void SetCategoria(Categoria categoria)
        {
            Categoria = categoria;
        }
        public virtual void SetFornecedor(Fornecedor fornecedor)
        {
            Fornecedor = fornecedor;
        }

        public virtual void SetImgPrincipalProduto(string? imgPrincipalProduto)
        {
            ImgPrincipalProduto = imgPrincipalProduto;
        }

        public virtual void SetImgSegundaProduto(string? imgSegundaProduto)
        {
            ImgSegundaProduto = imgSegundaProduto;
        }
        
        public virtual void SetImgTerceiraProduto(string? imgTerceiraProduto)
        {
            ImgTerceiraProduto = imgTerceiraProduto;
        }
    }
}