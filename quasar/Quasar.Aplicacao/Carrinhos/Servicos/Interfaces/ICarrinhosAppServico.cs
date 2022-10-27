using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Carrinhos.Requests;
using Quasar.DataTransfer.Carrinhos.Responses;

namespace Quasar.Aplicacao.Carrinhos.Servicos.Interfaces
{
    public interface ICarrinhosAppServico
    {
        void Inserir (CarrinhoInserirRequest carrinhoInserirRequest);
        void Editar(CarrinhoEditarRequest carrinhoEditarRequest);
        void Deletar(int codigo);
    }
}