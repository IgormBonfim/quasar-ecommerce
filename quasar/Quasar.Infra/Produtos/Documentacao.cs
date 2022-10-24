using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Produtos.Repositorios;

namespace Quasar.Infra.Produtos
{
    public class ProdutosRepositorioDocumentacao //: IProdutosRepositorio
    {

        //campo session privado do tipo ISession para utilizar os metodos do ISession do NHibernate
        private readonly ISession session;

        //Construtor que recebe ISession e atribui ao campo session
        public ProdutosRepositorioDocumentacao(ISession session)
        {
            this.session = session;
        }

        //Metodo que recebe um Produto e remove ele do banco de dados
        //Equivalente a um "DELETE FROM PRODUTOS WHERE IDPRODUTO = IDINFORMADO" no MySQL

        public void Deletar(Produto produto)
        {
            session.Delete(produto);
        }

        //Metodo que recebe com os valores atualizado e atualiza no banco de dados
        //Equivalente a um "UPDATE PRODUTOS SET COLUNA = "VALOR ATUALIZADO" WHERE IDPRODUTO = IDINFORMADO" no MySQL
        public Produto Editar(Produto produto)
        {
            session.Update(produto);
            return produto;
        }

        //Insere produto no banco que devolve o id gerado pelo banco
        //Equivalente a um "INSERT INTO PRODUTOS VALUES(CAMPOS DE PRODUTO)" no MySQL
        //Adiciona o id gerado ao produto
        //Retorna o produto com o id
        public Produto Inserir(Produto produto)
        {
            int codigo = (int)session.Save(produto);
            produto.SetCodigo(codigo);
            return produto;
        }

        //Metodo que retorna uma IQueryable de Produto para que a Query seja montada
        public IQueryable<Produto> Query()
        {
            return session.Query<Produto>();
        }


        //Metodo que recupera um produto no banco de dados
        //Equivalente a um "SELECT * FROM PRODUTOS WHERE IDPRODUTO = IDINFORMADO" no MySQL
        public Produto Recuperar(int codigo)
        {
            return session.Get<Produto>(codigo);
        }
    }
}