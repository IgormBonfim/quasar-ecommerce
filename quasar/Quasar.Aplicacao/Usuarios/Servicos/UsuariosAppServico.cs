using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NHibernate;
using Quasar.Aplicacao.Usuarios.Servicos.Interfaces;
using Quasar.DataTransfer.Usuarios.Requests;
using Quasar.DataTransfer.Usuarios.Responses;
using Quasar.Dominio.Usuarios.Entidades;
using Quasar.Dominio.Usuarios.Enumeradores;
using Quasar.Dominio.Usuarios.Excecoes;
using Quasar.Dominio.Usuarios.Servicos.Interfaces;

namespace Quasar.Aplicacao.Usuarios.Servicos
{
    public class UsuariosAppServico : IUsuariosAppServico
    {
        private readonly IUsuariosServico usuariosServico;
        private readonly IClientesServico clientesServico;
        private readonly ISession session;
        private readonly IMapper mapper;

        public UsuariosAppServico(IUsuariosServico usuariosServico, IClientesServico clientesServico, ISession session, IMapper mapper)
        {
            this.clientesServico = clientesServico;
            this.session = session;
            this.mapper = mapper;
            this.usuariosServico = usuariosServico;
        }

        public async Task<UsuarioCadastroResponse> Cadastrar(UsuarioCadastroRequest cadastroRequest)
        {
            var response = new UsuarioCadastroResponse();

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

                response.Sucesso = await usuariosServico.Cadastrar(usuario, cadastroRequest.Senha);

                if (transacao.IsActive)
                    transacao.Commit();
            }
            catch (UsuarioInvalidoExcecao e)
            {
                if (transacao.IsActive)
                    transacao.Rollback();
                response.Erro = e.Message;
                response.Sucesso = false;
            }
            return response;
        }

        public async Task<UsuarioLoginResponse> Login(UsuarioLoginRequest loginRequest)
        {
            var response = new UsuarioLoginResponse();
            try
            {
                response.Token = await usuariosServico.Login(loginRequest.Login, loginRequest.Senha);

                return response;
            }
            catch (LoginInvalidoExcecao e)
            {
                response.Sucesso = false;
                response.Erro = e.Message;
                return response;
            }
        }

        public UsuarioResponse Recuperar(string codigo)
        {
            Usuario usuario = usuariosServico.Validar(codigo);
            
            return mapper.Map<UsuarioResponse>(usuario);
        }
    }
}