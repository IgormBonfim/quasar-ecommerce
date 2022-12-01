using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NHibernate;
using Quasar.Aplicacao.Enderecos.Servicos.Interfaces;
using Quasar.DataTransfer.Enderecos.Requests;
using Quasar.DataTransfer.Enderecos.Responses;
using Quasar.DataTransfer.Genericos.Responses;
using Quasar.Dominio.Categorias.Repositorios;
using Quasar.Dominio.Enderecos.Entidades;
using Quasar.Dominio.Enderecos.Repositorios;
using Quasar.Dominio.Enderecos.Servicos;
using Quasar.Dominio.Enderecos.Servicos.Interfaces;
using Quasar.Dominio.Genericos.Entidades;

namespace Quasar.Aplicacao.Enderecos.Servicos
{
    public class EnderecosAppServico : IEnderecosAppServico
    {
        private readonly ISession session;
        private readonly IEnderecosServico enderecosServico;
        private readonly IEnderecosRepositorio enderecosRepositorio;
        private readonly IMapper mapper;

        public EnderecosAppServico(ISession session, IEnderecosServico enderecosServico, IEnderecosRepositorio enderecosRepopsitorio, IMapper mapper)
        {
            this.session = session;
            this.enderecosServico = enderecosServico;
            this.enderecosRepositorio = enderecosRepositorio;
            this.mapper = mapper;
        }
        public EnderecoResponse Inserir(EnderecoInserirRequest inserirRequest)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                Endereco EnderecoInserir = enderecosServico.Instanciar(inserirRequest.Numero, inserirRequest.Bairro, inserirRequest.Rua, inserirRequest.PontoReferencia, inserirRequest.Complemento, inserirRequest.Cep, inserirRequest.CodigoCidade, inserirRequest.CodigoUsuario);
                Endereco enderecoSalvo = enderecosServico.Inserir(EnderecoInserir);

                if(transacao.IsActive)
                    transacao.Commit();
                
                return mapper.Map<EnderecoResponse>(enderecoSalvo);
            }
            catch
            {
                if(transacao.IsActive)
                    transacao.Rollback();
                throw;
            }
        }

        public EnderecoResponse Recuperar(int codigo)
        {
            try
            {
                Endereco endereco = enderecosServico.Validar(codigo);
                return mapper.Map<EnderecoResponse>(endereco);
            }
            catch
            {
                throw;
            }
        }

        public void Deletar(int codigo)
        {
            ITransaction transacao = session.BeginTransaction();

            try
            {
                enderecosServico.Deletar(codigo);
                if(transacao.IsActive)
                transacao.Commit();
            }
            catch
            {
                if(transacao.IsActive)
                transacao.Rollback();
                throw;
            }
        }

        public EnderecoResponse Editar(EnderecoEditarRequest editarRequest)
        {
            ITransaction transacao = session.BeginTransaction();
            try
            {
                Endereco enderecoEditar = enderecosServico.Instanciar(editarRequest.Numero.Value, editarRequest.Bairro, editarRequest.Rua, editarRequest.PontoReferencia, editarRequest.Complemento, editarRequest.Cep, editarRequest.CodigoCidade.Value, editarRequest.CodigoUsuario);
                enderecoEditar.SetCodigo(editarRequest.Codigo);

                Endereco enderecoSalvo = enderecosServico.Editar(enderecoEditar);
                if(transacao.IsActive)
                transacao.Commit();
                return mapper.Map<EnderecoResponse>(enderecoSalvo);
            }
            catch
            {
                if(transacao.IsActive)
                transacao.Rollback();
                throw;
            }
        }

        public ListaPaginadaResponse<EnderecoResponse> Listar(EnderecoListarRequest listarRequest)
        {
          try
          {  
            IQueryable<Endereco> query = enderecosRepositorio.Query();

            if (listarRequest.CodUsuario != null)
                {
                    query = query.Where(f => f.Usuario.Id == listarRequest.CodUsuario);
                }
            ListaPaginada<Endereco> listaEndereco = enderecosRepositorio.Listar(query, listarRequest.Quantidade, listarRequest.Pagina);
            return mapper.Map<ListaPaginadaResponse<EnderecoResponse>>(listaEndereco);
          }
          catch
          {
            throw;
          }
        }
    }
}