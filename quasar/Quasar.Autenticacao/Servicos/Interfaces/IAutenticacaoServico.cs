using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.DataTransfer.Usuarios.Requests;
using Quasar.DataTransfer.Usuarios.Responses;

namespace Quasar.Autenticacao.Servicos.Interfaces
{
    public interface IAutenticacaoServico
    {
        Task<UsuarioCadastroResponse> Cadastrar(UsuarioCadastroRequest cadastroRequest);
        Task<UsuarioLoginResponse> Login(UsuarioLoginRequest loginRequest);
    }
}