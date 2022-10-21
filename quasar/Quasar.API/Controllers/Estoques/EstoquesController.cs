using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quasar.Aplicacao.Estoques.Servicos;
using Quasar.Aplicacao.Estoques.Servicos.Interfaces;
using Quasar.DataTransfer.Estoques.Requests;

namespace Quasar.API.Controllers.Estoques
{
    [ApiController]
    [Route("api/estoques")]
    public class EstoquesController : ControllerBase
    {
        private readonly IEstoquesAppServico estoquesAppServico;

        public EstoquesController(IEstoquesAppServico estoquesAppServico)
        {
            this.estoquesAppServico = estoquesAppServico;
        }

        [HttpPost]
        public IActionResult Inserir([FromBody]EstoqueInserirRequest inserirRequest)
        {
            var retorno = estoquesAppServico.Inserir(inserirRequest);
            return Ok(retorno);
        }

        [HttpPut("{codigo}")]
        public ActionResult Editar(int codigo, EstoqueEditarRequest editarRequest)
        {
            editarRequest.Codigo = codigo;
            var retorno = estoquesAppServico.Editar(editarRequest);
            return Ok(retorno);
        }

        [HttpGet("{codigo}")]
        public IActionResult Recuperar(int codigo)
        {
            var retorno = estoquesAppServico.Recuperar(codigo);
            return Ok(retorno);
        }
    }
}
