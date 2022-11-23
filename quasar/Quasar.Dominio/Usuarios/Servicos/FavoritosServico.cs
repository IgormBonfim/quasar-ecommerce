using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Produtos.Servicos.Interfaces;
using Quasar.Dominio.Usuarios.Entidades;
using Quasar.Dominio.Usuarios.Servicos.Interfaces;

namespace Quasar.Dominio.Usuarios.Servicos
{
    public class FavoritosServico : IFavoritosServico
    {
        private readonly IUsuariosServico usuariosServico;
        private readonly IProdutosServico produtosServico;

        public FavoritosServico(IUsuariosServico usuariosServico, IProdutosServico produtosServico)
        {
            this.usuariosServico = usuariosServico;
            this.produtosServico = produtosServico;
        }   

        public Produto Adicionar(int codProduto, string codUsuario)
        {
            Usuario usuario = usuariosServico.Validar(codUsuario);
            Produto produto = produtosServico.Validar(codProduto);
             
            foreach (var produtos in usuario.Favoritos)
            {
                if (produtos == produto)
                    throw new Exception("Produto já foi favoritado.");
            }
            usuario.Favoritos.Add(produto);
            usuariosServico.Editar(usuario);
            return produto;
        }

        public Produto Remover(int codProduto, string codUsuario)
        {
            Usuario usuario = usuariosServico.Validar(codUsuario);
            Produto produto = produtosServico.Validar(codProduto);

            usuario.Favoritos.Remove(produto);
            usuariosServico.Editar(usuario);
            return produto;
        }

        public IList<Produto> Listar(string codUsuario)
        {
            Usuario usuario = usuariosServico.Validar(codUsuario);
     
            return usuario.Favoritos;
        }
    }
}