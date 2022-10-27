using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Usuarios.Requests;

namespace Quasar.Aplicacao.Usuarios.Servicos.Interfaces
{
    public interface IFavoritosAppServico
    {
        void Adicionar(FavoritoRequest favoritoRequest);
        void Remover(FavoritoRequest favoritoRequest);
    }
}