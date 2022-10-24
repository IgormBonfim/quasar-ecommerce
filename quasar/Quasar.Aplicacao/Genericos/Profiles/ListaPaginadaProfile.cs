using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Quasar.DataTransfer.Genericos.Responses;
using Quasar.Dominio.Genericos.Entidades;

namespace Quasar.Aplicacao.Genericos.Profiles
{
    public class ListaPaginadaProfile : Profile
    {
        public ListaPaginadaProfile()
        {
            CreateMap(typeof(ListaPaginada<>), typeof(ListaPaginadaResponse<>));
        }
    }
}