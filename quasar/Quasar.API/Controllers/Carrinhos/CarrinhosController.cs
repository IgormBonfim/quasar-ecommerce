using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quasar.Aplicacao.Carrinhos.Servicos.Interfaces;
using Quasar.DataTransfer.Carrinhos.Requests;

namespace Quasar.API.Controllers.Carrinhos
{
    [ApiController]
    [Authorize]
    [Route("api/carrinhos")]
    public class CarrinhosController : ControllerBase
    {
        private readonly ICarrinhosAppServico carrinhosAppServico;

        public CarrinhosController(ICarrinhosAppServico carrinhosAppServico)
        {
            this.carrinhosAppServico = carrinhosAppServico;
        }

        [HttpPost]
        public IActionResult Inserir([FromBody]CarrinhoInserirRequest inserirRequest)
        {
            carrinhosAppServico.Inserir(inserirRequest);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Deletar(int codigo)
        {
            carrinhosAppServico.Deletar(codigo);
            return Ok();
        }

        [HttpPut]
        public IActionResult Editar([FromBody]CarrinhoEditarRequest carrinhoEditar)
        {
            carrinhosAppServico.Editar(carrinhoEditar);
            return Ok();
        }
    }
}