using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using NSubstitute;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Produtos.Servicos;
using Quasar.Dominio.Produtos.Servicos.Interfaces;
using Quasar.Dominio.Usuarios.Entidades;
using Quasar.Dominio.Usuarios.Servicos;
using Quasar.Dominio.Usuarios.Servicos.Interfaces;
using Xunit;

namespace Quasar.Dominio.Testes.Usuarios.Servicos
{
    public class FavoritosServicoTestes
    {
        private readonly FavoritosServico sut;
        private readonly IUsuariosServico usuariosServico;
        private readonly IProdutosServico produtosServico; 
        private readonly Usuario usuarioValido; 
        private readonly Produto produtoValido;

        public FavoritosServicoTestes()
        {
            usuariosServico = Substitute.For<IUsuariosServico>();
            produtosServico = Substitute.For<IProdutosServico>();
            sut = new FavoritosServico(usuariosServico, produtosServico);
            usuarioValido = Builder<Usuario>.CreateNew().Build();
            produtoValido = Builder<Produto>.CreateNew().Build();
        }

        public class AdicionarMetodo : FavoritosServicoTestes
        {
            [Fact]
            public void Quando_FavoritoForEncontrado_Espero_ProdutoValido()
            {
                IList<Produto> favoritos = new List<Produto>();
                favoritos.Add(produtoValido);
                usuarioValido.SetFavoritos(favoritos);
                this.usuariosServico.Validar(Arg.Any<string>()).Returns(usuarioValido);
                sut.Invoking(x => x.Adicionar(1, "").Should().BeSameAs(produtoValido));
            }
            [Fact]
            public void Quando_FavoritoNaoForEncontrado_Espero_Exception()
            {
                this.usuariosServico.Validar(Arg.Any<string>()).Returns(usuarioValido);
                sut.Invoking(x => x.Adicionar(1, "")).Should().Throw<Exception>();
            }
        }

        public class RemoverMetodo : FavoritosServicoTestes
        {
            [Fact]
            public void Quando_FavoritoForRemovido_Espero_Exception()
            {
                sut.Invoking(x => x.Remover(1, "").Should().BeSameAs(produtoValido));
            }
        }

        public class ListarMetodo : FavoritosServicoTestes
        {
            [Fact]
            public void Quando_FavoritoForListado_Espero_Excepcion()
            {
                IList<Produto> favoritos = new List<Produto>();                
                sut.Invoking(x => x.Listar("").Should().BeSameAs(favoritos));
            }
        }
    }
}