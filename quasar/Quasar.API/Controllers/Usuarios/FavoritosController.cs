using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quasar.Aplicacao.Genericos.Servicos.Interfaces;
using Quasar.Aplicacao.Usuarios.Servicos.Interfaces;
using Quasar.DataTransfer.Usuarios.Requests;

namespace Quasar.API.Controllers.Usuarios
{
    [Authorize]
    [ApiController]
    [Route("api/favoritos")]
    public class FavoritosController : ControllerBase
    {
        private readonly IFavoritosAppServico favoritosAppServico;
        private readonly IUsuario usuario;

        public FavoritosController(IFavoritosAppServico favoritosAppServico, IUsuario usuario)
        {
            this.favoritosAppServico = favoritosAppServico;
            this.usuario = usuario;
        }

        [HttpPost("adicionar")]
        public IActionResult Adicionar ([FromBody] FavoritoRequest adicionarRequest)
        {
            adicionarRequest.codUsuario = usuario.UsuarioLogado(HttpContext);
            favoritosAppServico.Adicionar(adicionarRequest);
            return Ok();
        }

        [HttpPost("remover")]
        public IActionResult Remover ([FromBody] FavoritoRequest removerRequest)
        {
            removerRequest.codUsuario = usuario.UsuarioLogado(HttpContext);
            favoritosAppServico.Remover(removerRequest);
            return Ok();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            FavoritoListarRequest favoritoListarRequest = new FavoritoListarRequest();
            favoritoListarRequest.codUsuario = usuario.UsuarioLogado(HttpContext);
            var retorno = favoritosAppServico.Listar(favoritoListarRequest);
            return Ok(retorno);
        }
    }
}