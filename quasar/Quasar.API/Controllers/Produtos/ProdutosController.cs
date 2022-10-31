using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quasar.Aplicacao.Produtos.Servicos.Interfaces;
using Quasar.DataTransfer.Genericos.Responses;
using Quasar.DataTransfer.Produtos.Requests;
using Quasar.DataTransfer.Produtos.Responses;

namespace Quasar.API.Controllers.Produtos
{
    [Authorize]
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

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<ListaPaginadaResponse<ProdutoResponse>> Listar([FromQuery] ProdutoBuscarRequest buscarRequest)
        {
            var retorno = produtosAppServico.Listar(buscarRequest);
            return Ok(retorno);
        }

        [AllowAnonymous]
        [HttpGet("{codigo}")]
        public ActionResult<ProdutoResponse> Recuperar(int codigo)
        {
            var retorno = produtosAppServico.Recuperar(codigo);
            return Ok(retorno);
        }

        [HttpDelete("{codigo}")]
        public IActionResult Deletar(int codigo)
        {
            produtosAppServico.Deletar(codigo);
            return Ok();
        }

        [HttpPut("{codigo}")]
        public ActionResult<ProdutoResponse> Editar(int codigo, [FromBody] ProdutoEditarRequest editarRequest)
        {
            editarRequest.Codigo = codigo;
            var retorno = produtosAppServico.Editar(editarRequest);
            return Ok(retorno);
        }
    }
}