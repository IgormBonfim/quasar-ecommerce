using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Quasar.DataTransfer.Cidades.Responses;
using Quasar.Dominio.Cidades.Entidades;

namespace Quasar.Aplicacao.Cidades.Profiles
{
    public class CidadesProfile : Profile
    {
        public CidadesProfile()
        {
            CreateMap<Cidade, CidadeResponse>();
        }
    }
}