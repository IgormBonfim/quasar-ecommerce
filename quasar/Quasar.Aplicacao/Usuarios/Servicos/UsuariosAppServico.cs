using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IAutenticacaoServico autenticacaoServico;
        private readonly IClientesServico clientesServico;
        public UsuariosAppServico(IAutenticacaoServico autenticacaoServico, IClientesServico clientesServico)
        {
            this.clientesServico = clientesServico;
            this.autenticacaoServico = autenticacaoServico;
        }

        public UsuarioCadastroResponse Cadastrar(UsuarioCadastroRequest cadastroRequest)
        {
            try
            {
                string nomeCompleto = cadastroRequest.Cliente.Nome + cadastroRequest.Cliente.Sobrenome;

                Cliente cliente = clientesServico.Instanciar(
                    nomeCompleto,
                    cadastroRequest.Cliente.NomeFantasia,
                    cadastroRequest.Cliente.CpfCnpj,
                    cadastroRequest.Cliente.InscricaoEstadual,
                    cadastroRequest.Cliente.RazaoSocial,
                    (TipoClienteEnum)cadastroRequest.Cliente.TipoCliente);

                cliente = clientesServico.Inserir(cliente);

                UsuarioCadastroResponse usuarioCadastroResponse = autenticacaoServico.Cadastrar(cadastroRequest, cliente.Codigo).Result;
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