using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Quasar.DataTransfer.Ufs.Responses;
using Quasar.Dominio.Ufs.Entidades;

namespace Quasar.Aplicacao.Ufs.Profiles
{
    public class UfsProfile : Profile
    {
        public UfsProfile()
        {
            CreateMap<Uf, UfResponse>();
        }
        
    }
}