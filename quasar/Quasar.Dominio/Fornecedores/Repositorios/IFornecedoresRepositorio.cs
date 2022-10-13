using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Fornecedores.Entidades;

namespace Quasar.Dominio.Fornecedores.Repositorios
{
    public interface IFornecedoresRepositorio
    {
        Fornecedor Inserir(Fornecedor fornecedor);
        Fornecedor Editar(Fornecedor fornecedor);
        void Deletar(Fornecedor fornecedor);
        Fornecedor Recuperar(int codigo);
        IQueryable<Fornecedor> Query();
    }
}