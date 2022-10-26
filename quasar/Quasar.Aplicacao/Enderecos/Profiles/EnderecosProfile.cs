using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Quasar.DataTransfer.Enderecos.Responses;
using Quasar.Dominio.Enderecos.Entidades;

namespace Quasar.Aplicacao.Enderecos.Profiles
{
    public class EnderecosProfile : Profile
    {
        public EnderecosProfile()
        {
            CreateMap<Endereco, EnderecoResponse>();
        }
    }
}