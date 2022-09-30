using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Fornecedores.Responses;

namespace Quasar.Aplicacao.Fornecedores.Servicos.Interfaces
{
    public interface IFornecedoresAppServico
    {
        FornecedorResponse Recuperar(int idFornecedor);
        FornecedorInserirResponse Inserir(FornecedorInserirRequest fornecedorInserirRequest);
    }
}