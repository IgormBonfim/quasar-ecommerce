using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Quasar.Aplicacao.Usuarios.Servicos.Interfaces;
using Quasar.Autenticacao.Servicos.Interfaces;
using Quasar.DataTransfer.Usuarios.Requests;
using Quasar.DataTransfer.Usuarios.Responses;
using Quasar.Dominio.Usuarios.Entidades;
using Quasar.Dominio.Usuarios.Enumeradores;
using Quasar.Dominio.Usuarios.Servicos.Interfaces;

namespace Quasar.Aplicacao.Usuarios.Servicos
{
    public class UsuariosAppServico : IUsuariosAppServico
    {
        private readonly IUsuariosServico usuariosServico;
        private readonly IClientesServico clientesServico;
        private readonly ISession session;

        public UsuariosAppServico(IUsuariosServico usuariosServico, IClientesServico clientesServico, ISession session)
        {
            this.clientesServico = clientesServico;
            this.session = session;
            this.usuariosServico = usuariosServico;
        }

        public UsuarioCadastroResponse Cadastrar(UsuarioCadastroRequest cadastroRequest)
        {
            ITransaction transacao = session.BeginTransaction();
            try
            {
                string nomeCompleto = $"{cadastroRequest.Cliente.Nome} {cadastroRequest.Cliente.Sobrenome}";

                Cliente cliente = clientesServico.Instanciar(
                    nomeCompleto,
                    cadastroRequest.Cliente.NomeFantasia,
                    cadastroRequest.Cliente.CpfCnpj,
                    cadastroRequest.Cliente.InscricaoEstadual,
                    cadastroRequest.Cliente.RazaoSocial,
                    (TipoClienteEnum)cadastroRequest.Cliente.TipoCliente);

                cliente = clientesServico.Inserir(cliente);

                Usuario usuario = usuariosServico.Instanciar(cadastroRequest.Email, cliente.Codigo);

                UsuarioCadastroResponse response = new UsuarioCadastroResponse(usuariosServico.Cadastrar(usuario, cadastroRequest.Senha).Result);

                if(transacao.IsActive)
                    transacao.Commit();
                return response;
            }
            catch
            {
                if(transacao.IsActive)
                    transacao.Rollback();
                throw;
            }
        }

        public UsuarioLoginResponse Login(UsuarioLoginRequest loginRequest)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch
            {
                throw;
            }
        }
    }
}