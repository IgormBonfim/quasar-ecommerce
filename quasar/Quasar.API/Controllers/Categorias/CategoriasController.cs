using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpPost]
        public IActionResult Inserir ([FromBody]CategoriaInserirRequest inserirRequest)
        {
            var retorno = categoriasAppServico.Inserir(inserirRequest);
            return Ok(retorno);
        }
        [HttpPut("{id}")]
        public IActionResult Editar (int id, [FromBody] CategoriaEditarRequest editarRequest)
        {
            editarRequest.IdCategoria = id;

            var retorno = categoriasAppServico.Editar(editarRequest);
            return Ok(retorno);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            categoriasAppServico.Deletar(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult Buscar([FromQuery] CategoriaBuscarRequest buscarRequest)
        {
            var retorno = categoriasAppServico.Buscar(buscarRequest);
            return Ok(retorno);
        }

        [HttpGet("{id}")]
        public IActionResult Recuperar (int id)
        {
            var retorno = categoriasAppServico.Recuperar(id);
            return Ok(retorno);
        }
    }
}