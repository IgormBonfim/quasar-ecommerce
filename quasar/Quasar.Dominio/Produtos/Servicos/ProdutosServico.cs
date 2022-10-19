using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Categorias.Entidades;
using Quasar.Dominio.Categorias.Servicos.Interfaces;
using Quasar.Dominio.Fornecedores.Entidades;
using Quasar.Dominio.Fornecedores.Servicos.Interfaces;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Produtos.Repositorios;
using Quasar.Dominio.Produtos.Servicos.Interfaces;

namespace Quasar.Dominio.Produtos.Servicos
{
    public class ProdutosServico : IProdutosServico
    {

        //Campo que tem todos os metodos de ProdutosRepositorio
        private readonly IProdutosRepositorio produtosRepositorio;
        private readonly IEspecificacoesServico especificacoesServico;
        private readonly ICategoriasServico categoriasServico;
        private readonly IFornecedoresServico fornecedoresServico;

        //Construtor que recebe um IProdutosRepositorio
        public ProdutosServico(IProdutosRepositorio produtosRepositorio, IEspecificacoesServico especificacoesServico, ICategoriasServico categoriasServico, IFornecedoresServico fornecedoresServico)
        {
            this.fornecedoresServico = fornecedoresServico;
            this.produtosRepositorio = produtosRepositorio;
            this.especificacoesServico = especificacoesServico;
            this.categoriasServico = categoriasServico;
        }

        //Recebe o id do produto que será deletado e valida se esse produto existe no banco
        //Metodo que chama o metodo de deletar de ProdutosRepositorio
        //Não retorna nada
        public void Deletar(int codigo)
        {
            Produto produtoDeletar = Validar(codigo);
            produtosRepositorio.Deletar(produtoDeletar);
        }

        //Metodo que recebe um produto, verifica se esse produto existe no banco
        //Compara todos os campos e altera os que estiverem diferente
        //Retorna o produto atualizado no banco
        public Produto Editar(Produto produto)
        {
            Produto produtoEditar = Validar(produto.Codigo);

            if (produto.Nome != produtoEditar.Nome)
                produtoEditar.SetNome(produto.Nome);

            if (produto.Descricao != produtoEditar.Descricao) 
                produtoEditar.SetDescricao(produto.Descricao);

            if (produto.Imagem != produtoEditar.Imagem) 
                produtoEditar.SetImagem(produto.Imagem);

            // if (produto.Categoria != produtoEditar.Categoria)
            //     produtoEditar.SetCategoria(produto.Categoria);

            // if (produto.Fornecedor != produtoEditar.Fornecedor)
            //     produtoEditar.SetFornecedor(produto.Fornecedor);

            return produtosRepositorio.Editar(produtoEditar);
        }

        //Metodo que chama o metodo de inserir do ProdutosRepositorio
        //Recebe um Produto
        //Retorna um Produto com o id do Produto inserido no banco de dados
        public Produto Inserir(Produto produto)
        {
            int codigo = produtosRepositorio.Inserir(produto);
            produto.SetCodigo(codigo);
            return produto;
        }

        //Metodo que Instancia um novo objeto do tipo Produto
        //Recebe as informações do produto
        //Retorna um Produto

        public Produto Instanciar(string? descricao, string? nome, string? imagem, int codigoEspecificacao, int codFornecedor, int codCategoria)
        {
            Especificacao especificacaoBanco = especificacoesServico.Validar(codigoEspecificacao);
            Fornecedor fornecedor = fornecedoresServico.Validar(codFornecedor);
            Categoria categoria = categoriasServico.Validar(codCategoria);

            Produto produto = new Produto(descricao, nome, imagem, especificacaoBanco, categoria, fornecedor);
            return produto;
        }

        //Metodo que valida se um produto existe no banco
        //Recebe o id do produto a ser validado
        //Retorna o produto caso exista no banco
        public Produto Validar(int codigo)
        {
            Produto produtoValidar = produtosRepositorio.Recuperar(codigo);
            if (produtoValidar == null)
                throw new Exception("Produto não encontado.");
            return produtoValidar;
        }
    }
}