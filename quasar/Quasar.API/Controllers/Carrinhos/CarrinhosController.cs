using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quasar.Aplicacao.Carrinhos.Servicos.Interfaces;
using Quasar.DataTransfer.Carrinhos.Requests;

namespace Quasar.API.Controllers.Carrinhos
{
    [ApiController]
    [Route("api/[controller]")]
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
            var retorno = carrinhosAppServico.Inserir(inserirRequest);
            return Ok(retorno);
        }
    }
}