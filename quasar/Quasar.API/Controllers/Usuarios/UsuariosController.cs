using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quasar.Aplicacao.Usuarios.Servicos.Interfaces;
using Quasar.DataTransfer.Usuarios.Requests;
using Quasar.DataTransfer.Usuarios.Responses;

namespace Quasar.API.Controllers.Usuarios
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosAppServico usuariosAppServico;
        public UsuariosController(IUsuariosAppServico usuariosAppServico)
        {
            this.usuariosAppServico = usuariosAppServico;
        }

        [HttpPost("cadastrar")]
        public ActionResult<UsuarioCadastroResponse> Cadastrar([FromBody] UsuarioCadastroRequest cadastroRequest)
        {
            var retorno = usuariosAppServico.Cadastrar(cadastroRequest);
            return Ok(retorno);
        }

        [HttpPost("login")]
        public ActionResult<UsuarioLoginResponse> Login([FromBody] UsuarioLoginRequest loginRequest)
        {
            var retorno = usuariosAppServico.Login(loginRequest);
            return Ok(retorno);
        }
    }
}