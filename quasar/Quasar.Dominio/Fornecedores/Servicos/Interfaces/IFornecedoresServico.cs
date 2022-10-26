using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Fornecedores.Entidades;

namespace Quasar.Dominio.Fornecedores.Servicos.Interfaces
{
    public interface IFornecedoresServico
    {
        Fornecedor Validar(int codigo);
        Fornecedor Inserir(Fornecedor fornecedor);
        Fornecedor Instanciar(string? nome, string? razaoSocial, string? cnpj, string? ie);
        Fornecedor Editar(Fornecedor fornecedor);
        void Deletar(int codigo);
    }
}