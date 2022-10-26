using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Enderecos.Requests;
using Quasar.DataTransfer.Enderecos.Responses;

namespace Quasar.Aplicacao.Enderecos.Servicos.Interfaces
{
    public interface IEnderecosAppServico
    {
        EnderecoResponse Inserir(EnderecoInserirRequest inserirRequest);
        EnderecoResponse Editar (EnderecoEditarRequest editarRequest);
        EnderecoResponse Recuperar (int codigo);
        void Deletar (int codigo);
    }
}