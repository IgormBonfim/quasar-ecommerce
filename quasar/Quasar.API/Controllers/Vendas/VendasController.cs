using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quasar.Aplicacao.Genericos.Servicos.Interfaces;
using Quasar.Aplicacao.Vendas.Servicos.Interfaces;
using Quasar.DataTransfer.Vendas.Request;

namespace Quasar.API.Controllers.Vendas
{
    [Authorize]
    [ApiController]
    [Route("api/vendas")]
    public class VendasController : ControllerBase
    {
        private readonly IVendasAppServico vendasAppServico;
        private readonly IUsuario usuario;

        public VendasController(IVendasAppServico vendasAppServico, IUsuario usuario)
        {
            this.vendasAppServico = vendasAppServico;
            this.usuario = usuario;
        }
        [HttpGet("{codigo}")]
        public IActionResult Recuperar(int codigo)
        {
            var retorno = vendasAppServico.Recuperar(codigo);
            return Ok(retorno);
        }
        [HttpPost]
        public IActionResult Inserir([FromBody] VendaInserirRequest inserirRequest)
        {
            inserirRequest.CodUsuario = usuario.UsuarioLogado(HttpContext);
            var retorno = vendasAppServico.Inserir(inserirRequest);
            return Ok(retorno);
        }
        [HttpGet]
        public IActionResult Listar([FromQuery] VendaListarRequest vendaRequest)
        {
            vendaRequest.CodUsuario = usuario.UsuarioLogado(HttpContext);
            var retorno = vendasAppServico.Listar(vendaRequest);
            return Ok(retorno);
        }
    }
}