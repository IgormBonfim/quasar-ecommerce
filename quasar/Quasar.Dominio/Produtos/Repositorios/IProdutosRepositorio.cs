using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Produtos.Entidades;

namespace Quasar.Dominio.Produtos.Repositorios
{
    public interface IProdutosRepositorio
    {
        Produto Inserir(Produto produto);
        Produto Editar(Produto produto);
        void Deletar(Produto produto);
        Produto Recuperar(int cod);
        IQueryable<Produto> Query();
    }
}