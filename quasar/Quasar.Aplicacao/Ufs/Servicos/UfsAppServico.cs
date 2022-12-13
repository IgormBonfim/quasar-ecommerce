using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NHibernate;
using Quasar.Aplicacao.Ufs.Servicos.Interfaces;
using Quasar.DataTransfer.Ufs.Responses;
using Quasar.Dominio.Ufs.Entidades;
using Quasar.Dominio.Ufs.Repositorios;
using Quasar.Dominio.Ufs.Servicos.Interfaces;

namespace Quasar.Aplicacao.Ufs.Servicos
{
    public class UfsAppServico : IUfsAppServico
    {
        private readonly ISession session;
        private readonly IUfsServico ufsServico;
        private readonly IUfsRepositorio ufsRepositorio;
        private readonly IMapper mapper;

        public UfsAppServico(ISession session, IUfsServico ufsServico, IUfsRepositorio ufsRepositorio, IMapper mapper)
        {
            this.session = session;
            this.ufsServico = ufsServico;
            this.ufsRepositorio = ufsRepositorio;
            this.mapper = mapper;
        }

        public IList<UfResponse> Listar()
        {
            try
            {
                IQueryable<Uf> query = ufsRepositorio.Query();
                IList<Uf> listaUf = query.ToList();
                return mapper.Map<IList<UfResponse>>(listaUf);
            }
            catch 
            {
                
                throw;
            }
        }

        public UfResponse Recuperar(int codigo)
        {
            try
            {
                Uf ufResponse = ufsServico.Validar(codigo);
                return mapper.Map<UfResponse>(ufResponse);
            }

            catch
            {
                throw;
            }
        }
    }
}