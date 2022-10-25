using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Carrinhos.Entidades;
using Quasar.Dominio.Carrinhos.Repositorios;
using Quasar.Dominio.Carrinhos.Servicos.Interfaces;
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

        public CarrinhosServico(ICarrinhosRepositorio carrinhosRepositorio, IProdutosServico produtosServico, IUsuariosServico usuarioServico)
        {
            this.carrinhosRepositorio = carrinhosRepositorio;
            this.produtosServico = produtosServico;
            this.usuarioServico = usuarioServico;
        }
        public void Deletar(int codigo)
        {
            Carrinho carrinhoDeletar = Validar(codigo);
            carrinhosRepositorio.Deletar(carrinhoDeletar);
        }

        public Carrinho Editar(Carrinho carrinho)
        {
            Carrinho carrinhoEditar = Validar(carrinho.Codigo);
            
            if(carrinho.Quantidade != carrinhoEditar.Quantidade)
                carrinhoEditar.SetQuantidade(carrinho.Quantidade);
            
            if(carrinho.Usuario != carrinhoEditar.Usuario)
                carrinhoEditar.SetUsuario(carrinho.Usuario);
            
            if(carrinho.Produto != carrinhoEditar.Produto)
                carrinhoEditar.SetProduto(carrinho.Produto);

            return carrinhoEditar;
        }
    

        public Carrinho Inserir(Carrinho carrinho)
        {
            int codigo = carrinhosRepositorio.Inserir(carrinho);
            carrinho.SetCodigo(codigo);
            return carrinho;
        }

        public Carrinho Instanciar(int quantidade, int codProduto, string codUsuario)
        {
            Produto produto = produtosServico.Validar(codProduto);
            Usuario usuario = usuarioServico.Validar(codUsuario);
            Carrinho carrinho = new Carrinho(quantidade, produto, usuario);
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