using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Carrinhos.Entidades;
using Quasar.Dominio.Carrinhos.Repositorios;
using Quasar.Dominio.Carrinhos.Servicos.Interfaces;
using Quasar.Dominio.Estoques.Entidades;
using Quasar.Dominio.Estoques.Servicos.Interfaces;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Produtos.Servicos.Interfaces;
using Quasar.Dominio.Usuarios.Entidades;
using Quasar.Dominio.Usuarios.Servicos.Interfaces;

namespace Quasar.Dominio.Carrinhos.Servicos
{
    public class CarrinhosServico : ICarrinhosServico
    {
        private readonly ICarrinhosRepositorio carrinhosRepositorio;
        private readonly IProdutosServico produtosServico;
        private readonly IUsuariosServico usuarioServico;
        private readonly IEstoquesServico estoqueServico;

        public CarrinhosServico(ICarrinhosRepositorio carrinhosRepositorio, IProdutosServico produtosServico, IUsuariosServico usuarioServico, IEstoquesServico estoqueServico)
        {
            this.carrinhosRepositorio = carrinhosRepositorio;
            this.produtosServico = produtosServico;
            this.usuarioServico = usuarioServico;
            this.estoqueServico = estoqueServico;
        }
        public void Deletar(int codigo)
        {
            Carrinho carrinhoDeletar = Validar(codigo);
            carrinhosRepositorio.Deletar(carrinhoDeletar);
        }

        public Carrinho Editar(Carrinho carrinho, int codEstoque)
        {
            Carrinho carrinhoEditar = Validar(carrinho.Codigo);

            Estoque estoque = estoqueServico.Validar(codEstoque);
            
            if(carrinho.Quantidade != carrinhoEditar.Quantidade && carrinho.Quantidade <= estoque.Quantidade)
                carrinhoEditar.SetQuantidade(carrinho.Quantidade);

            return carrinhoEditar;
        }
    

        public Carrinho Inserir(Carrinho carrinho)
        {
            var query = carrinhosRepositorio.Query()
                                            .Where(u => u.Usuario.Codigo == carrinho.Usuario.Codigo)
                                            .Where(p => p.Produto.Codigo == carrinho.Produto.Codigo)
                                            .FirstOrDefault();

            if(query != null)
                throw new Exception("O produto ja esta no carrinho");

            int codigo = carrinhosRepositorio.Inserir(carrinho);
            carrinho.SetCodigo(codigo);
            return carrinho;
        }

        public Carrinho Instanciar(int? quantidade, int? codProduto, string? codUsuario)
        {
            Produto produto = produtosServico.Validar(codProduto.Value);
            Usuario usuario = usuarioServico.Validar(codUsuario);
            Carrinho carrinho = new Carrinho(quantidade.Value, produto, usuario);
            return carrinho;
        }

        public Carrinho Validar(int codigo)
        {
            Carrinho carrinhoValidar = carrinhosRepositorio.Recuperar(codigo);
            if(carrinhoValidar == null)
                throw new Exception("O produto não foi encontrado em seu carrinho.");
            return carrinhoValidar;
        }
    }
}