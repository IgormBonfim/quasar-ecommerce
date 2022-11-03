using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quasar.Aplicacao.Categorias.Servicos.Interfaces;
using Quasar.DataTransfer.Categorias.Requests;

namespace Quasar.API.Controllers.Categorias
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasAppServico categoriasAppServico;

        public CategoriasController (ICategoriasAppServico categoriasAppServico)
        {
            this.categoriasAppServico = categoriasAppServico;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Inserir ([FromBody]CategoriaInserirRequest inserirRequest)
        {
            var retorno = categoriasAppServico.Inserir(inserirRequest);
            return Ok(retorno);
        }

        [Authorize]
        [HttpPut("{codigo}")]
        public IActionResult Editar (int codigo, [FromBody] CategoriaEditarRequest editarRequest)
        {
            editarRequest.Codigo = codigo;

            var retorno = categoriasAppServico.Editar(editarRequest);
            return Ok(retorno);
        }

        [Authorize]
        [HttpDelete("{codigo}")]
        public IActionResult Deletar (int codigo)
        {
            categoriasAppServico.Deletar(codigo);
            return Ok();
        }

        [HttpGet]
        public IActionResult Buscar([FromQuery] CategoriaBuscarRequest buscarRequest)
        {
            var retorno = categoriasAppServico.Buscar(buscarRequest);
            return Ok(retorno);
        }

        [HttpGet("{codigo}")]
        public IActionResult Recuperar (int codigo)
        {
            var retorno = categoriasAppServico.Recuperar(codigo);
            return Ok(retorno);
        }
    }
}