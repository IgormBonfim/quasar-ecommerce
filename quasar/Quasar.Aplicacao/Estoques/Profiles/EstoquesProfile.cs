using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Quasar.DataTransfer.Estoques.Responses;
using Quasar.Dominio.Estoques.Entidades;

namespace Quasar.Aplicacao.Estoques.Profiles
{
    public class EstoquesProfile : Profile
    {
        public EstoquesProfile()
        {
            CreateMap<Estoque, EstoqueInserirResponse>();
            CreateMap<Estoque, EstoqueEditarResponse>();
            CreateMap<Estoque, EstoqueResponse>();
        }
    }
}