using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NHibernate;
using Quasar.Aplicacao.Cidades.Servicos.Interfaces;
using Quasar.DataTransfer.Cidades.Requests;
using Quasar.DataTransfer.Cidades.Responses;
using Quasar.Dominio.Cidades.Entidades;
using Quasar.Dominio.Cidades.Repositorios;
using Quasar.Dominio.Cidades.Servicos.Interfaces;
using Quasar.Infra.Cidades;

namespace Quasar.Aplicacao.Cidades.Servicos
{
    public class CidadesAppServico : ICidadesAppServico
    {
        
        private readonly ISession session;
        private readonly ICidadesServico cidadesServico;
        private readonly ICidadesRepositorio cidadesRepositorio;
        private readonly IMapper mapper;

        public CidadesAppServico(ISession session, ICidadesServico cidadesServico, ICidadesRepositorio cidadesRepositorio, IMapper mapper)
        {
            this.session = session;
            this.cidadesServico = cidadesServico;
            this.cidadesRepositorio = cidadesRepositorio;
            this.mapper = mapper;
        }

        public IList<CidadeResponse> Listar(CidadeBuscarRequest buscarRequest)
        {
            try
            {
                IQueryable<Cidade> query = cidadesRepositorio.Query();

                if(buscarRequest.CodUf != null)
                {
                    query = query.Where(f => f.Uf.Codigo == buscarRequest.CodUf);
                }

                if(buscarRequest.Nome != null)
                {
                    query = query.Where(f => f.Nome.Contains(buscarRequest.Nome));
                }

                IList<Cidade> listarCidades = cidadesServico.Listar(query);

                return mapper.Map<IList<CidadeResponse>>(listarCidades);
            }
            catch 
            {
                throw;
            }
        }

        public CidadeResponse Recuperar(int codigo)
        {
            try
            {
                Cidade cidade = cidadesServico.Validar(codigo);
                return mapper.Map<CidadeResponse>(cidade);
                
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}