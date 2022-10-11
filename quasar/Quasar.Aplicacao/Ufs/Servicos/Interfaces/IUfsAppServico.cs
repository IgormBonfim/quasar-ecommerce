using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Ufs.Responses;

namespace Quasar.Aplicacao.Ufs.Servicos.Interfaces
{
    public interface IUfsAppServico
    {
        UfResponse Recuperar(int cod);
        IList<UfResponse> Listar();
    }
}