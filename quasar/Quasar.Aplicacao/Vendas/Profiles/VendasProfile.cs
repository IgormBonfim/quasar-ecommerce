using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Quasar.DataTransfer.Vendas.Responses;
using Quasar.Dominio.Vendas.Entidades;

namespace Quasar.Aplicacao.Vendas.Profiles
{
    public class VendasProfile : Profile
    {
        public VendasProfile()
        {
            CreateMap<Venda, VendaResponse>();
            CreateMap<Venda, VendaEditarResponse>();
            CreateMap<Venda, VendaInserirResponse>();
        }
    }
}