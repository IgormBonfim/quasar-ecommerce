using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Genericos.Responses;
using Quasar.DataTransfer.Produtos.Requests;
using Quasar.DataTransfer.Produtos.Responses;
using Quasar.Dominio.Produtos.Entidades;

namespace Quasar.Aplicacao.Produtos.Servicos.Interfaces
{
    public interface IProdutosAppServico
    {
        ProdutoInserirResponse Inserir(ProdutoInserirRequest inserirRequest);
        ListaPaginadaResponse<ProdutoResponse> Listar(ProdutoBuscarRequest buscarRequest);
    }
}