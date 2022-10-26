using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quasar.Aplicacao.Usuarios.Servicos.Interfaces;
using Quasar.DataTransfer.Usuarios.Requests;

namespace Quasar.API.Controllers.Usuarios
{
    [ApiController]
    [Route("api/favoritos")]
    public class FavoritosController : ControllerBase
    {
        private readonly IFavoritosAppServico favoritosAppServico;
        public FavoritosController(IFavoritosAppServico favoritosAppServico)
        {
            this.favoritosAppServico = favoritosAppServico;
        }

        [HttpPost("adicionar")]
        public IActionResult Adicionar ([FromBody] FavoritoRequest adicionarRequest)
        {
            favoritosAppServico.Adicionar(adicionarRequest);
            return Ok();
        }

        [HttpPost("remover")]
        public IActionResult Remover ([FromBody] FavoritoRequest removerRequest)
        {
            favoritosAppServico.Remover(removerRequest);
            return Ok();
        }

    }
}