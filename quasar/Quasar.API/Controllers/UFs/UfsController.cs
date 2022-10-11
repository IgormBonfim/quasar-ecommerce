using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quasar.Aplicacao.Ufs.Servicos.Interfaces;

namespace Quasar.API.Controllers.UFs
{
    [ApiController]
    [Route("api/ufs")]
    public class UfsController : ControllerBase
    {
        private readonly IUfsAppServico ufsAppServico;

        public UfsController(IUfsAppServico ufsAppServico)
        {
            this.ufsAppServico = ufsAppServico;
        }

    [HttpGet]
    public IActionResult Listar()
    {
        var retorno = ufsAppServico.Listar();
        return Ok(retorno);
    }

    [HttpGet("{id}")]
    public IActionResult Recuperar(int cod)
    {
        var retorno = ufsAppServico.Recuperar(cod);
        return Ok(retorno);
    }

    }
}