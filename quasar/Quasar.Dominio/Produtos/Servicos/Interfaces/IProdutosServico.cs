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
        Produto Validar(int id);
        Produto Inserir(Produto produto);
        Produto Instanciar(string? descricaoProduto, string? nomeProduto, string? imgProduto, int codigoEspecificacao);
        Produto Editar(Produto produto);
        void Deletar(int idProduto);
    }
}