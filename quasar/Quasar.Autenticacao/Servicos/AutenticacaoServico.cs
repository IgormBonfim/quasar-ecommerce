using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Quasar.Autenticacao.Configuracoes;
using Quasar.Autenticacao.Servicos.Interfaces;
using Quasar.DataTransfer.Usuarios.Requests;
using Quasar.DataTransfer.Usuarios.Responses;

namespace Quasar.Autenticacao.Servicos
{
    public class AutenticacaoServico : IAutenticacaoServico
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IJwtServico jwtServico;

        public AutenticacaoServico(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IJwtServico jwtServico)
        {
            this.jwtServico = jwtServico;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public async Task<UsuarioCadastroResponse> Cadastrar(UsuarioCadastroRequest cadastroRequest)
        {
            var identityUser = new IdentityUser
            {
                UserName = cadastroRequest.Email,
                Email = cadastroRequest.Email,
                EmailConfirmed = true,
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
            var result = await signInManager.PasswordSignInAsync(loginRequest.Email, loginRequest.Senha, false, true);
            if (result.Succeeded)
            {
                IdentityUser usuario = await userManager.FindByEmailAsync(loginRequest.Email);
                return await jwtServico.GerarToken(usuario);
            }

            var usuarioLoginResponse = new UsuarioLoginResponse(result.Succeeded);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                    usuarioLoginResponse.AdicionarErro("Essa conta está bloqueada");
                else if (result.IsNotAllowed)
                    usuarioLoginResponse.AdicionarErro("Essa conta não tem permissão para fazer login");
                else if (result.RequiresTwoFactor)
                    usuarioLoginResponse.AdicionarErro("É necessário confirmar o login no seu segundo fator de autenticação");
                else
                    usuarioLoginResponse.AdicionarErro("Usuário ou senha estão incorretos");
            }

            return usuarioLoginResponse;
        }
    }
}