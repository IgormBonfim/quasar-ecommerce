using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Quasar.DataTransfer.Usuarios.Responses;
using Quasar.Dominio.Usuarios.Entidades;

namespace Quasar.Aplicacao.Usuarios.Profiles
{
    public class ClientesProfile : Profile
    {
        public ClientesProfile()
        {
            CreateMap<Cliente, ClienteResponse>();
        }
    }
}