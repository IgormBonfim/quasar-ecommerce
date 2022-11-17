using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Usuarios.Entidades;
using Quasar.Dominio.Usuarios.Repositorios;
using Quasar.Dominio.Usuarios.Servicos.Interfaces;

namespace Quasar.Dominio.Usuarios.Servicos
{
    public class UsuariosServico : IUsuariosServico
    {
        private readonly IUsuariosRepositorio usuariosRepositorio;
        private readonly IClientesServico clientesServico;

        public UsuariosServico(IUsuariosRepositorio usuariosRepositorio, IClientesServico clientesServico)
        {
            this.usuariosRepositorio = usuariosRepositorio;
            this.clientesServico = clientesServico;
        }

        public async Task<bool> Cadastrar(Usuario usuario, string senha)
        {
            var result = await usuariosRepositorio.Inserir(usuario, senha);
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

        public Usuario Validar(string codigo)
        {
            Usuario usuario = usuariosRepositorio.Recuperar(codigo);
            if (usuario == null)
                throw new Exception("Usuario não encontrado");
            return usuario;
        }

        
    }
}