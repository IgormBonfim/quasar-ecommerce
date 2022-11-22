using System;
using System.Collections.Generic;
using System.Linq;
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
            SignInResult loginCpf = await signInManager.PasswordSignInAsync(login, senha, false, true);

            if(loginCpf.Succeeded)
            {
                Usuario usuario = await userManager.FindByNameAsync(login);
                return await tokensServico.GerarToken(usuario);
            }
            else
            {
                Usuario? usuario = UsuarioPorEmail(login);

                if(usuario != null)
                {
                    SignInResult loginEmail = await signInManager.PasswordSignInAsync(usuario, senha, false, true);

                    if(loginEmail.Succeeded)
                    {
                        return await tokensServico.GerarToken(usuario);
                    }
                }
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

        
    }
}