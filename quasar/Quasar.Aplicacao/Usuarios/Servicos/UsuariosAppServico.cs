using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Aplicacao.Usuarios.Servicos.Interfaces;
using Quasar.Autenticacao.Servicos.Interfaces;
using Quasar.DataTransfer.Usuarios.Requests;
using Quasar.DataTransfer.Usuarios.Responses;

namespace Quasar.Aplicacao.Usuarios.Servicos
{
    public class UsuariosAppServico : IUsuariosAppServico
    {
        private readonly IAutenticacaoServico autenticacaoServico;
        public UsuariosAppServico(IAutenticacaoServico autenticacaoServico)
        {
            this.autenticacaoServico = autenticacaoServico;
        }

        public UsuarioCadastroResponse Cadastrar(UsuarioCadastroRequest cadastroRequest)
        {
            try
            {
                UsuarioCadastroResponse usuarioCadastroResponse = autenticacaoServico.Cadastrar(cadastroRequest).Result;
                return usuarioCadastroResponse;
            }
            catch
            {
                throw;
            }
        }

        public UsuarioLoginResponse Login(UsuarioLoginRequest loginRequest)
        {
            try
            {
                return autenticacaoServico.Login(loginRequest).Result;
            }
            catch
            {
                throw;
            }
        }
    }
}