using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Quasar.Autenticacao.Configuracoes;
using Quasar.Autenticacao.Entidades;
using Quasar.Autenticacao.Servicos.Interfaces;
using Quasar.DataTransfer.Usuarios.Requests;
using Quasar.DataTransfer.Usuarios.Responses;

namespace Quasar.Autenticacao.Servicos
{
    public class AutenticacaoServico : IAutenticacaoServico
    {
        private readonly SignInManager<Usuario> signInManager;
        private readonly UserManager<Usuario> userManager;
        private readonly IJwtServico jwtServico;

        public AutenticacaoServico(SignInManager<Usuario> signInManager, UserManager<Usuario> userManager, IJwtServico jwtServico)
        {
            this.jwtServico = jwtServico;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public async Task<UsuarioCadastroResponse> Cadastrar(UsuarioCadastroRequest cadastroRequest, int codigoCliente)
        {
            var identityUser = new Usuario
            {
                UserName = cadastroRequest.Cliente.CpfCnpj,
                Email = cadastroRequest.Email,
                EmailConfirmed = true,
                CodCliente = codigoCliente
            };

            var result = await userManager.CreateAsync(identityUser, cadastroRequest.Senha);

            UsuarioCadastroResponse usuarioCadastroResponse = new UsuarioCadastroResponse(result.Succeeded);

            if (result.Succeeded)
            {
                await userManager.SetLockoutEnabledAsync(identityUser, false);
            }

            if (!result.Succeeded && result.Errors.Count() > 0)
                usuarioCadastroResponse.AdicionarErros(result.Errors.Select(erro => erro.Description));

            return usuarioCadastroResponse;
        }

        public async Task<UsuarioLoginResponse> Login(UsuarioLoginRequest loginRequest)
        {

            var usuario = await userManager.FindByNameAsync(loginRequest.Email);
            if(usuario == null)
            {
                usuario = await userManager.FindByEmailAsync(loginRequest.Email);
                if (usuario == null)
                {
                    var response = new UsuarioLoginResponse(false);
                    response.AdicionarErro("Usuário ou senha estão incorretos");
                    return response;
                }
            }

            var login = await signInManager.PasswordSignInAsync(usuario, loginRequest.Senha, false, true);
            if (login.Succeeded)
            {
                return await jwtServico.GerarToken(usuario);
            }

            var usuarioLoginResponse = new UsuarioLoginResponse(login.Succeeded);
            if (!login.Succeeded)
            {
                if (login.IsLockedOut)
                    usuarioLoginResponse.AdicionarErro("Essa conta está bloqueada");
                else if (login.IsNotAllowed)
                    usuarioLoginResponse.AdicionarErro("Essa conta não tem permissão para fazer login");
                else if (login.RequiresTwoFactor)
                    usuarioLoginResponse.AdicionarErro("É necessário confirmar o login no seu segundo fator de autenticação");
                else
                    usuarioLoginResponse.AdicionarErro("Usuário ou senha estão incorretos");
            }

            return usuarioLoginResponse;
        }
    }
}