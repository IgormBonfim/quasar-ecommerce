using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Cidades.Requests;
using Quasar.DataTransfer.Cidades.Responses;

namespace Quasar.Aplicacao.Cidades.Servicos.Interfaces
{
    public interface ICidadesAppServico
    {
        CidadeResponse Recuperar (int codigo);
        IList<CidadeResponse> Listar (CidadeBuscarRequest buscarRequest);
    }

}