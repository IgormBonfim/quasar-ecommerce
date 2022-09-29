using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quasar.Aplicacao.FormasPagamento.Servicos.Interfaces;

namespace Quasar.API.Controllers.FormasPagamento
{
    [ApiController]
    [Route("api/formaspagamento")]
    public class FormasPagamentoController : ControllerBase
    {
        private readonly IFormasPagamentoAppServico formasPagamentoAppServico;

        public FormasPagamentoController(IFormasPagamentoAppServico formasPagamentoAppServico)
        {
            this.formasPagamentoAppServico = formasPagamentoAppServico;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var retorno = formasPagamentoAppServico.Listar();
            return Ok(retorno);
        }

        [HttpGet("{id}")]
        public IActionResult Recuperar(int id)
        {
            var retorno = formasPagamentoAppServico.Recuperar(id);
            return Ok(retorno);
        }
    }
}