using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Quasar.Dominio.Tokens.Servicos.Interfaces;
using Quasar.Dominio.Usuarios.Entidades;
using Quasar.Dominio.Usuarios.Excecoes;
using Quasar.Dominio.Usuarios.Repositorios;
using Quasar.Dominio.Usuarios.Servicos.Interfaces;

namespace Quasar.Dominio.Usuarios.Servicos
{
    public class UsuariosServico : IUsuariosServico
    {
        private readonly IUsuariosRepositorio usuariosRepositorio;
        private readonly IClientesServico clientesServico;
        private readonly ITokensServico tokensServico;
        private readonly SignInManager<Usuario> signInManager;
        private readonly UserManager<Usuario> userManager;

        public UsuariosServico(IUsuariosRepositorio usuariosRepositorio, IClientesServico clientesServico, ITokensServico tokensServico, SignInManager<Usuario> signInManager, UserManager<Usuario> userManager)
        {
            this.usuariosRepositorio = usuariosRepositorio;
            this.clientesServico = clientesServico;
            this.tokensServico = tokensServico;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<bool> Cadastrar(Usuario usuario, string senha)
        {
            var validarUsuario = UsuarioPorEmail(usuario.Email);

            if(validarUsuario != null)
                throw new UsuarioInvalidoExcecao("Este email já está em uso.");

            var result = await usuariosRepositorio.Inserir(usuario, senha);

            if (result.Succeeded)
                await userManager.SetLockoutEnabledAsync(usuario, false);

            return result.Succeeded;
        }

        public Usuario Editar(Usuario usuario)
        {
            return usuariosRepositorio.Editar(usuario);
        }

        public Usuario Instanciar(string email, int codCliente)
        {
            Cliente cliente = clientesServico.Validar(codCliente);

            return new Usuario(email, cliente);
        }

        public async Task<string> Login(string login, string senha)
        {
            bool loginCpfCnpj = await LoginPorCpfCnpj(login, senha);

            if (loginCpfCnpj)
            {
                Usuario usuario = await userManager.FindByNameAsync(login);

                return await tokensServico.GerarToken(usuario);
            }

            bool loginEmail = await LoginPorEmail(login, senha);

            if (loginEmail)
            {
                Usuario usuario = UsuarioPorEmail(login)!;
                
                return await tokensServico.GerarToken(usuario);
            } 
            
            throw new LoginInvalidoExcecao("Login ou senha estão incorretos.");
        }

        public Usuario Validar(string codigo)
        {
            Usuario usuario = usuariosRepositorio.Recuperar(codigo);
            if (usuario == null)
                throw new Exception("Usuario não encontrado");
            return usuario;
        }

        private Usuario? UsuarioPorEmail(string email)
        {
            return userManager.FindByEmailAsync(email).Result;
        }

        private async Task<bool> LoginPorCpfCnpj(string login, string senha)
        {
            Regex verificarCpfCnpj = new Regex(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})");

            bool cpfCnpjValido = verificarCpfCnpj.IsMatch(login);

            if (cpfCnpjValido)
            {
                var loginSucedido = await signInManager.PasswordSignInAsync(login, senha, false, true);

                if(loginSucedido.Succeeded)
                    return true;

                if (!loginSucedido.Succeeded)
                    {
                        if(loginSucedido.IsLockedOut)
                            throw new LoginInvalidoExcecao("Essa conta está bloqueada.");
                        if(loginSucedido.IsNotAllowed)
                            throw new LoginInvalidoExcecao("Essa conta não tem permissão para fazer login.");
                        if(loginSucedido.RequiresTwoFactor)
                            throw new LoginInvalidoExcecao("Necessário confirmar a autenticação de dois fatores.");
                    }
            }

            return false;
        }

        private async Task<bool> LoginPorEmail(string login, string senha)
        {
            Regex verificarEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            bool emailValido = verificarEmail.IsMatch(login);

            if (emailValido)
            {
                Usuario? usuario = UsuarioPorEmail(login);

                if (usuario != null)
                {
                    var loginSucedido = await signInManager.PasswordSignInAsync(usuario, senha, false, true);

                    if(loginSucedido.Succeeded)
                        return true;
                    
                    if (!loginSucedido.Succeeded)
                    {
                        if(loginSucedido.IsLockedOut)
                            throw new LoginInvalidoExcecao("Essa conta está bloqueada.");
                        if(loginSucedido.IsNotAllowed)
                            throw new LoginInvalidoExcecao("Essa conta não tem permissão para fazer login.");
                        if(loginSucedido.RequiresTwoFactor)
                            throw new LoginInvalidoExcecao("Necessário confirmar a autenticação de dois fatores.");
                    }
                }
            }

            return false;
        }
        
    }
}