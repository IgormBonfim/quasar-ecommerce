using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quasar.Aplicacao.Produtos.Servicos.Interfaces;
using Quasar.DataTransfer.Genericos.Responses;
using Quasar.DataTransfer.Produtos.Requests;
using Quasar.DataTransfer.Produtos.Responses;

namespace Quasar.API.Controllers.Produtos
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosAppServico produtosAppServico;

        public ProdutosController(IProdutosAppServico produtosAppServico)
        {
            this.produtosAppServico = produtosAppServico;
        }
        
        [HttpPost]
        public IActionResult Inserir([FromBody] ProdutoInserirRequest inserirRequest)
        {
            var retorno = produtosAppServico.Inserir(inserirRequest);
            return Ok(retorno);
        }

        [HttpGet]
        public ActionResult<ListaPaginadaResponse<ProdutoResponse>> Listar([FromQuery] ProdutoBuscarRequest buscarRequest)
        {
            var retorno = produtosAppServico.Listar(buscarRequest);
            return Ok(retorno);
        }
    }
}