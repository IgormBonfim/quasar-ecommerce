using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quasar.Aplicacao.Cidades.Servicos.Interfaces;
using Quasar.DataTransfer.Cidades.Requests;

namespace Quasar.API.Controllers.Cidades
{
    [ApiController]
    [Route("api/cidades")]
    public class CidadesController : ControllerBase
    {
        private readonly ICidadesAppServico cidadesAppServico;

        public CidadesController(ICidadesAppServico cidadesAppServico)
        {
            this.cidadesAppServico = cidadesAppServico;
        }

        [HttpGet("{codigo}")]
        public IActionResult Recuperar(int codigo)
        {
            var retorno = cidadesAppServico.Recuperar(codigo);
            return Ok(retorno);
        }

        [HttpGet]
        public IActionResult Buscar([FromQuery]CidadeBuscarRequest buscarRequest)
        {
            var retorno = cidadesAppServico.Listar(buscarRequest);
            return Ok(retorno);
        }
    }
}