using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Quasar.DataTransfer.Vendas.Responses;
using Quasar.Dominio.Vendas.Entidades;

namespace Quasar.Aplicacao.Vendas.Profiles
{
    public class StatusVendasProfile : Profile

    {
        public StatusVendasProfile()
        {
            CreateMap<StatusVenda, StatusVendaResponse>();
        }
    }
}