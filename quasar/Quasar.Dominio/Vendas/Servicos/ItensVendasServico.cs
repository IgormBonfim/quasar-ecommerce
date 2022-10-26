using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Produtos.Servicos.Interfaces;
using Quasar.Dominio.Vendas.Entidades;
using Quasar.Dominio.Vendas.Repositorios;
using Quasar.Dominio.Vendas.Servicos.Interfaces;

namespace Quasar.Dominio.Vendas.Servicos
{
    public class ItensVendasServico : IItensVendasServico
    {
        private readonly IItensVendasRepositorio itensVendasRepositorio;
        private readonly IVendasServico vendasServico;
        private readonly IProdutosServico produtoServico;

        public ItensVendasServico(IItensVendasRepositorio itensVendasRepositorio, IVendasServico vendasServico, IProdutosServico produtoServico)
        {
            this.itensVendasRepositorio = itensVendasRepositorio;
            this.vendasServico = vendasServico;
            this.produtoServico = produtoServico;
        }

        public ItemVenda Inserir(Produto produto, ItemVenda itemVenda)
        {
            int codigo = itensVendasRepositorio.Inserir(itemVenda);
            itemVenda.SetCodigo(codigo);
            return itemVenda;
        }
        public ItemVenda Instanciar(int quantidade, int codVenda, int codProduto, decimal valorUnitario)
        {
            Venda venda = vendasServico.Validar(codVenda);
            Produto produto = produtoServico.Validar(codProduto);

            ItemVenda itemVenda = new ItemVenda(quantidade, venda, produto, valorUnitario);
            return itemVenda;
        }
    }
}