using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Categorias.Entidades;
using Quasar.Dominio.Fornecedores.Entidades;
using Quasar.Dominio.Produtos.Entidades;

namespace Quasar.Dominio.Produtos.Servicos.Interfaces
{
    public interface IProdutosServico
    {
        Produto Validar(int codigo);
        Produto Inserir(Produto produto);
        Produto Instanciar(string? descricao, string? nome, decimal? valor, string? imagem, int? codigoEspecificacao, int? codFornecedor, int? codCategoria);
        Produto Editar(Produto produto);
        void Deletar(int codigo);
    }
}