using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Vendas.Entidades;

namespace Quasar.Dominio.Vendas.Servicos.Interfaces
{
    public interface IVendasServico
    {
        Venda Validar(int codigo);
        Venda Inserir(Venda venda);
        Venda Instanciar(int codStatusVenda, int codFormaPagamento, int codEndereco, string codUsuario);
        Venda Editar(int codigo, int codStatusVenda);
    }
}