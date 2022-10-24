using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Carrinhos.Entidades;
using Quasar.Dominio.Carrinhos.Repositorios;
using Quasar.Dominio.Carrinhos.Servicos.Interfaces;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Usuarios.Entidades;

namespace Quasar.Dominio.Carrinhos.Servicos
{
    public class CarrinhosServico : ICarrinhosServico
    {
        private readonly ICarrinhosRepositorio carrinhosRepositorio;

        public CarrinhosServico(ICarrinhosRepositorio carrinhosRepositorio)
        {
            this.carrinhosRepositorio = carrinhosRepositorio;
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

        public Carrinho Instanciar(int codigo, int quantidade, Produto produto, Usuario usuario)
        {
            Carrinho carrinho = new Carrinho(codigo, quantidade, produto, usuario);
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