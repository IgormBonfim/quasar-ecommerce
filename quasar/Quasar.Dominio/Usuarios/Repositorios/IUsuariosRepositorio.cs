using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Quasar.Dominio.Genericos;
using Quasar.Dominio.Usuarios.Entidades;

namespace Quasar.Dominio.Usuarios.Repositorios
{
    public interface IUsuariosRepositorio : IGenericosRepositorio<Usuario>
    {
        Usuario Recuperar(string codigo);
        Task<IdentityResult> Inserir(Usuario usuario, string senha);
    }
}