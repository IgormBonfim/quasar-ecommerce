using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Fornecedores.Requests;
using Quasar.DataTransfer.Fornecedores.Responses;
using Quasar.DataTransfer.Genericos.Responses;

namespace Quasar.Aplicacao.Fornecedores.Servicos.Interfaces
{
    public interface IFornecedoresAppServico
    {
        FornecedorResponse Recuperar(int codigo);
        FornecedorInserirResponse Inserir(FornecedorInserirRequest inserirRequest);
        FornecedorEditarResponse Editar(FornecedorEditarRequest editarRequest);
        ListaPaginadaResponse<FornecedorResponse> Listar(FornecedorListarRequest BuscarRequest);
        void Deletar (int codigo);
    }
}