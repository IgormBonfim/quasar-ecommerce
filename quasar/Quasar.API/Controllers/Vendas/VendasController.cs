using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quasar.Aplicacao.Vendas.Servicos.Interfaces;
using Quasar.DataTransfer.Vendas.Request;

namespace Quasar.API.Controllers.Vendas
{
    [ApiController]
    [Route("api/[venda]")]
    public class VendasController : ControllerBase
    {
        private readonly IVendasAppServico vendasAppServico;
        public VendasController(IVendasAppServico vendasAppServico)
        {
            this.vendasAppServico = vendasAppServico;
        }
    [HttpGet("codigo")]
    public IActionResult Recuperar(int codigo)
    {
        var retorno = vendasAppServico.Recuperar(codigo)
        return Ok(retorno);
    }
    [HttpPost]
    public IActionResult Inserir([FromBody]VendaInserirRequest inserirRequest)
    {
        var retorno = vendasAppServico.Inserir(inserirRequest);
        return Ok(retorno);
    }
    }
}