using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Produtos.Responses;

namespace Quasar.DataTransfer.Usuarios.Responses
{
    public class FavoritoListarResponse
    {
        public IList<ProdutoResponse> Favoritos { get; set; }
    }
}