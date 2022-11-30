using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Produtos.Entidades;

namespace Quasar.Dominio.Usuarios.Servicos.Interfaces
{
    public interface IFavoritosServico
    {
        Produto Remover (int codProduto, string codUsuario);
        Produto Adicionar (int codProduto, string codUsuario);
        IList<Produto> Listar (string codUsuario);
    }
}