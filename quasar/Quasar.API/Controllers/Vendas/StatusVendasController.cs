using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quasar.Aplicacao.Vendas.Servicos.Interfaces;

namespace Quasar.API.Controllers.Vendas
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

        [HttpGet("{id}")]
        public IActionResult Recuperar(int id)
        {
            var retorno = statusVendasAppServico.Recuperar(id);
            return Ok(retorno);
        }
        
    }
}