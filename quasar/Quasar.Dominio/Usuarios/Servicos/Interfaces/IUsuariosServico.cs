using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Usuarios.Entidades;

namespace Quasar.Dominio.Usuarios.Servicos.Interfaces
{
    public interface IUsuariosServico
    {
        Usuario Validar(string codigo);
        Usuario Editar(Usuario usuario);
        Usuario Instanciar(string email, int codCliente);
        Task<bool> Cadastrar(Usuario usuario, string senha);
        Task<string> Login(string login, string senha);
    }
}