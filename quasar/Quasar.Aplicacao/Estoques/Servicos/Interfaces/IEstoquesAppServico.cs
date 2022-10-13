using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Estoques.Requests;
using Quasar.DataTransfer.Estoques.Responses;

namespace Quasar.Aplicacao.Estoques.Servicos.Interfaces
{
    public interface IEstoquesAppServico
    {
        EstoqueInserirResponse Inserir(EstoqueInserirRequest inserirRequest);
        EstoqueEditarResponse Editar(EstoqueEditarRequest editarRequest);
        EstoqueResponse Recuperar(int codigo);
    }
}