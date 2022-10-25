using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Usuarios.Requests;
using Quasar.DataTransfer.Usuarios.Responses;

namespace Quasar.Aplicacao.Usuarios.Servicos.Interfaces
{
    public interface IUsuariosAppServico
    {
        UsuarioCadastroResponse Cadastrar(UsuarioCadastroRequest cadastroRequest);
        UsuarioLoginResponse Login(UsuarioLoginRequest loginRequest);
    }
}