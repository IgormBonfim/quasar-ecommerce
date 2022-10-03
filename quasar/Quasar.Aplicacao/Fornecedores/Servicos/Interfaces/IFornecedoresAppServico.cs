using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Fornecedores.Requests;
using Quasar.DataTransfer.Fornecedores.Responses;

namespace Quasar.Aplicacao.Fornecedores.Servicos.Interfaces
{
    public interface IFornecedoresAppServico
    {
        FornecedorResponse Recuperar(int id);
        FornecedorInserirResponse Inserir(FornecedorInserirRequest inserirRequest);
        FornecedorEditarResponse Editar(FornecedorEditarRequest editarRequest);
        IList<FornecedorResponse> Buscar (CategoriaBuscarRequest BuscarRequest);
        void Deletar (int id);
    }
}