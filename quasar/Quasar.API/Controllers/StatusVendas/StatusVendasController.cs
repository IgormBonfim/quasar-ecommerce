using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quasar.Aplicacao.StatusVendas.Servicos.Interfaces;

namespace Quasar.API.Controllers.StatusVendas
{
    [ApiController]
    [Route("api/statusvendas")]
    public class StatusVendasController : ControllerBase
    {
        private readonly IStatusVendasAppServico statusVendasAppServico;

        public StatusVendasController(IStatusVendasAppServico statusVendasAppServico)
        {
            this.statusVendasAppServico = statusVendasAppServico;
        }

        [HttpGet("{codigo}")]
        public IActionResult Recuperar(int codigo)
        {
            var retorno = statusVendasAppServico.Recuperar(codigo);
            return Ok(retorno);
        }
        
    }
}