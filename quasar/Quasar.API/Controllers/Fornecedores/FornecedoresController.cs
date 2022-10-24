using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quasar.Aplicacao.Fornecedores.Servicos.Interfaces;
using Quasar.DataTransfer.Fornecedores.Requests;

namespace Quasar.API.Controllers.Fornecedores
{
    [ApiController]
    [Authorize]
    [Route("api/fornecedores")]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedoresAppServico _fornecedoresAppServico;

        public FornecedoresController(IFornecedoresAppServico fornecedoresAppServico)
        {
            _fornecedoresAppServico = fornecedoresAppServico;
        }

        [HttpPost]
        public IActionResult Inserir([FromBody]FornecedorInserirRequest inserirRequest)
        {
            var retorno = _fornecedoresAppServico.Inserir(inserirRequest);
            return Ok(retorno);
        }

        [HttpPut("{codigo}")]
        public IActionResult Editar(int codigo, FornecedorEditarRequest editarRequest)
        {
            editarRequest.Codigo = codigo;
            var retorno = _fornecedoresAppServico.Editar(editarRequest);
            return Ok(retorno);
        }

        [HttpDelete("{codigo}")]
        public IActionResult Deletar (int codigo)
        {
            _fornecedoresAppServico.Deletar(codigo);
            return Ok();
        }

        [HttpGet]
        public IActionResult Listar([FromQuery]FornecedorListarRequest listarRequest)
        {
            var retorno = _fornecedoresAppServico.Listar(listarRequest);
            return Ok(retorno);
        }

        [HttpGet("{codigo}")]
        public IActionResult Recuperar(int codigo)
        {
            var retorno = _fornecedoresAppServico.Recuperar(codigo);
            return Ok(retorno);
        }
    }
}