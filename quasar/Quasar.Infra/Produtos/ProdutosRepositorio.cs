using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Produtos.Repositorios;

namespace Quasar.Infra.Produtos
{
    public class ProdutosRepositorio : IProdutosRepositorio
    {

        //campo privado para utilizar os metodos do ISession do NHibernate
        private readonly ISession session;

        //Construtor que recebe ISession
        public ProdutosRepositorio(ISession session)
        {
            this.session = session;
        }

        public void Deletar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Produto Editar(Produto produto)
        {
            throw new NotImplementedException();
        }

        //Insere produto no banco que devolve o id gerado pelo banco
        //Adiciona o id gerado ao produto
        //Retorna o produto com o id
        public Produto Inserir(Produto produto)
        {
            int id = (int)session.Save(produto);
            produto.SetIdProduto(id);
            return produto;
        }

        public IQueryable<Produto> Query()
        {
            throw new NotImplementedException();
        }

        public Produto Recuperar(int id)
        {
            return session.Get<Produto>(id);
        }
    }
}