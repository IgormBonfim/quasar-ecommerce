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
        public UsuariosServico(IUsuariosRepositorio usuariosRepositorio)
        {
            this.usuariosRepositorio = usuariosRepositorio;
            
        }

        public Usuario Editar(Usuario usuario)
        {
            return usuariosRepositorio.Editar(usuario);
        }

        public Usuario Validar(string codigo)
        {
            Usuario usuario = usuariosRepositorio.Recuperar(codigo);
            if (usuario == null)
                throw new Exception("Usuario não encontrado");
            return usuario; //eu sou um merda
        }

        
    }
}