using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NHibernate;
using Quasar.Aplicacao.Fornecedores.Servicos.Interfaces;
using Quasar.DataTransfer.Fornecedores.Requests;
using Quasar.DataTransfer.Fornecedores.Responses;
using Quasar.Dominio.Fornecedores.Entidades;
using Quasar.Dominio.Fornecedores.Repositorios;
using Quasar.Dominio.Fornecedores.Servicos.Interfaces;

namespace Quasar.Aplicacao.Fornecedores.Servicos
{
    public class FornecedoresAppServico : IFornecedoresAppServico
    {
        private readonly ISession session;
        private readonly IMapper mapper;
        private readonly IFornecedoresServico fornecedoresServico;
        private readonly IFornecedoresRepositorio fornecedoresRepositorio;

        public FornecedoresAppServico(ISession session, IMapper mapper, IFornecedoresServico fornecedoresServico, IFornecedoresRepositorio fornecedoresRepositorio)
        {
            this.session = session;
            this.mapper = mapper;
            this.fornecedoresServico = fornecedoresServico;
            this.fornecedoresRepositorio = fornecedoresRepositorio;
        }
        public IList<FornecedorResponse> Buscar(CategoriaBuscarRequest BuscarRequest)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public FornecedorEditarResponse Editar(FornecedorEditarRequest editarRequest)
        {
            throw new NotImplementedException();
        }

        public FornecedorInserirResponse Inserir(FornecedorInserirRequest inserirRequest)
        {
            throw new NotImplementedException();
        }

        public FornecedorResponse Recuperar(int id)
        {
            try
            {
                Fornecedor fornecedor = fornecedoresServico.Validar(id);
                return mapper.Map<FornecedorResponse>(fornecedor);
            }
            catch
            {
                return null;
            }
            
        }
    }
}