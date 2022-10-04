using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quasar.Aplicacao.Fornecedores.Servicos.Interfaces;
using Quasar.DataTransfer.Fornecedores.Requests;

namespace Quasar.API.Controllers.Fornecedores
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedoresAppServico fornecedoresAppServico;

        public FornecedoresController(IFornecedoresAppServico FornecedoresAppServico)
        {
            fornecedoresAppServico = FornecedoresAppServico;
        }

        [HttpPost]
        public IActionResult Inserir([FromBody]FornecedorInserirRequest inserirRequest)
        {
            var retorno = fornecedoresAppServico.Inserir(inserirRequest);
            return Ok(retorno);
        }

        [HttpPut]
        public IActionResult Editar(FornecedorEditarRequest editarRequest)
        {
            var retorno = fornecedoresAppServico.Editar(editarRequest);
            return Ok(retorno);
        }

        [HttpDelete]
        public IActionResult Deletar (int id)
        {
            fornecedoresAppServico.Deletar(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult Listar(FornecedorListarRequest listarRequest)
        {
            var retorno = fornecedoresAppServico.Listar(listarRequest);
            return Ok(retorno);
        }

        [HttpGet("{Id}")]
        public IActionResult Recuperar(int id)
        {
            var retorno = fornecedoresAppServico.Recuperar(id);
            return Ok(retorno);
        }
    }
}