using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Fornecedores.Entidades;

namespace Quasar.Dominio.Fornecedores.Servicos.Interfaces
{
    public interface IFornecedoresServico
    {
        Fornecedor Validar(int id);
        Fornecedor Inserir(Fornecedor fornecedor);
        Fornecedor Instanciar(string? nomeFornecedor, string? razaoSocialFornecedor, string? cnpjFornecedor, string? ieFornecedor);
        Fornecedor Editar(Fornecedor forncedor);
        void Deletar(int idProduto);
    }
}