using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Vendas.Entidades;

namespace Quasar.Dominio.Vendas.Servicos.Interfaces
{
    public interface IItensVendasServico
    {
        ItemVenda Inserir(Produto produto, ItemVenda itemVenda);
        ItemVenda Instanciar(int quantidade, int codVenda, int codProduto, decimal valorUnitario);
    }
}