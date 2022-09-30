using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Quasar.DataTransfer.FormasPagamento.Responses;
using Quasar.Dominio.FormasPagamento.Entidades;

namespace Quasar.Aplicacao.FormasPagamento.Profiles
{
    public class FormasPagamentoProfile : Profile
    {
        public FormasPagamentoProfile()
        {
            CreateMap<FormaPagamento, FormaPagamentoResponse>();
        }
    }
}