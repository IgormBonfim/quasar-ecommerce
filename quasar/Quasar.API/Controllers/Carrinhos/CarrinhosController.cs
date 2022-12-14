using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quasar.Aplicacao.Carrinhos.Servicos.Interfaces;
using Quasar.Aplicacao.Genericos.Servicos.Interfaces;
using Quasar.DataTransfer.Carrinhos.Requests;
using Quasar.DataTransfer.Carrinhos.Responses;
using Quasar.DataTransfer.Genericos.Responses;

namespace Quasar.API.Controllers.Carrinhos
{
    [ApiController]
    [Authorize]
    [Route("api/carrinhos")]
    public class CarrinhosController : ControllerBase
    {
        private readonly ICarrinhosAppServico carrinhosAppServico;
        private readonly IUsuario usuario;

        public CarrinhosController(ICarrinhosAppServico carrinhosAppServico, IUsuario usuario)
        {
            this.carrinhosAppServico = carrinhosAppServico;
            this.usuario = usuario;
        }

        [HttpPost]
        public IActionResult Inserir([FromBody]CarrinhoInserirRequest inserirRequest)
        {
            inserirRequest.CodUsuario = usuario.UsuarioLogado(HttpContext);
            carrinhosAppServico.Inserir(inserirRequest);
            return Ok();
        }

        [HttpDelete("{codigo}")]
        public IActionResult Deletar(int codigo)
        {
            carrinhosAppServico.Deletar(codigo);
            return Ok();
        }

        [HttpPut("{codigo}")]
        public IActionResult Editar(int codigo, [FromBody]CarrinhoEditarRequest carrinhoEditar)
        {
            carrinhoEditar.Codigo = codigo; 
            carrinhosAppServico.Editar(carrinhoEditar);
            return Ok();
        }

        [HttpGet]
        public ActionResult<ListaPaginadaResponse<CarrinhoResponse>> Listar([FromQuery]CarrinhoListarRequest carrinhoListar)
        {
            carrinhoListar.CodUsuario = usuario.UsuarioLogado(HttpContext);
            var retorno = carrinhosAppServico.Listar(carrinhoListar);
            return Ok(retorno);
        }
    }
}