using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Quasar.DataTransfer.Usuarios.Responses;
using Quasar.Dominio.Usuarios.Entidades;

namespace Quasar.Aplicacao.Usuarios.Profiles
{
    public class UsuariosProfile : Profile
    {
        public UsuariosProfile()
        {
            CreateMap<Usuario, UsuarioResponse>().ForMember(dest => dest.Codigo, m => m.MapFrom(src => src.Id));
        }
    }
}