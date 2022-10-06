using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Quasar.DataTransfer.StatusVendas.Responses;
using Quasar.Dominio.StatusVendas.Entidades;

namespace Quasar.Aplicacao.StatusVendas.Profiles
{
    public class StatusVendasProfile : Profile

    {
        public StatusVendasProfile()
        {
            CreateMap<StatusVenda, StatusVendaResponse>();
        }
    }
}