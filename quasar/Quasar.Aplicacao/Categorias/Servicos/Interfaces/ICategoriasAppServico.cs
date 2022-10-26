using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Categorias.Requests;
using Quasar.DataTransfer.Categorias.Responses;
using Quasar.DataTransfer.Genericos.Responses;

namespace Quasar.Aplicacao.Categorias.Servicos.Interfaces
{
    public interface ICategoriasAppServico
    {
        CategoriaInserirResponse Inserir(CategoriaInserirRequest inserirResquest);
        CategoriaEditarResponse Editar (CategoriaEditarRequest editarRequest);
        CategoriaResponse Recuperar (int codigo);
        void Deletar (int codigo);
        ListaPaginadaResponse<CategoriaResponse> Buscar (CategoriaBuscarRequest buscarRequest);
    }
}