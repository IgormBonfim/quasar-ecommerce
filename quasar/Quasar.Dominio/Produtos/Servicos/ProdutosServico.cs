using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Categorias.Entidades;
using Quasar.Dominio.Fornecedores.Entidades;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Produtos.Repositorios;
using Quasar.Dominio.Produtos.Servicos.Interfaces;

namespace Quasar.Dominio.Produtos.Servicos
{
    public class ProdutosServico : IProdutosServico
    {

        //Campo que tem todos os metodos de ProdutosRepositorio
        private readonly IProdutosRepositorio produtosRepositorio;

        //Construtor que recebe um IProdutosRepositorio
        public ProdutosServico(IProdutosRepositorio produtosRepositorio)
        {
            this.produtosRepositorio = produtosRepositorio;
        }

        public void Deletar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Produto Editar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Produto Inserir(Produto produto)
        {
            return produtosRepositorio.Inserir(produto);
        }

        public Produto Instanciar(string? descricaoProduto, string? nomeProduto, Categoria? categoria, Fornecedor? fornecedor, string? imgPrincipalProduto, string? imgSegundaProduto, string? imgTerceiraProduto)
        {
            Produto produto = new Produto(descricaoProduto, nomeProduto, categoria, fornecedor, imgPrincipalProduto, imgSegundaProduto, imgTerceiraProduto);
            return produto;
        }

        public Produto Validar(int id)
        {
            throw new NotImplementedException();
        }
    }
}