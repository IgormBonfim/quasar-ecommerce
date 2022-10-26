using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quasar.Aplicacao.Enderecos.Servicos;
using Quasar.Aplicacao.Enderecos.Servicos.Interfaces;
using Quasar.DataTransfer.Enderecos.Requests;

namespace Quasar.API.Controllers.Enderecos
{
    [ApiController]
    [Route("api/enderecos")]
    public class EnderecosController : ControllerBase
    {
        private readonly IEnderecosAppServico enderecosAppServico;

        public EnderecosController(IEnderecosAppServico enderecosAppServico)
        {
            this.enderecosAppServico = enderecosAppServico;
        }
        [HttpPost]
        public IActionResult Inserir ([FromBody] EnderecoInserirRequest inserirResquest)
        {
            var retorno = enderecosAppServico.Inserir(inserirResquest);
            return Ok(retorno);
        }
        [HttpPut ("{codigo}")]
        public IActionResult Editar (int codigo, [FromBody] EnderecoEditarRequest editarRequest)
        {
            editarRequest.Codigo = codigo;
            var retorno = enderecosAppServico.Editar(editarRequest);
            return Ok(retorno);
        }
        [HttpDelete("{codigo}")]
        public IActionResult Deletar (int codigo)
        {
            enderecosAppServico.Deletar(codigo);
            return Ok();
        }
        [HttpGet("{codigo}")]
        public IActionResult Recuperar (int codigo)
        {
            var retorno = enderecosAppServico.Recuperar(codigo);
            return Ok(retorno);
        }
    }
}