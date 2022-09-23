using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Produtos.Entidades;

namespace Quasar.Aplicacao.Produtos.Servicos.Interfaces
{
    public interface IProdutosAppServico
    {
        IList<Produto> Listar();
    }
}