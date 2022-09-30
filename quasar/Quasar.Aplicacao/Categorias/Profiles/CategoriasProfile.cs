using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Quasar.DataTransfer.Categorias.Responses;
using Quasar.Dominio.Categorias.Entidades;

namespace Quasar.Aplicacao.Categorias.Profiles
{
    public class CategoriasProfile : Profile
    {
        public CategoriasProfile()
        {
            CreateMap<Categoria, CategoriaInserirResponse>();
            CreateMap<Categoria, CategoriaEditarResponse>();
            CreateMap<Categoria, CategoriaResponse>();
            //CreateMap<Categoria, CategoriaRecuperarResponse>();
            //CreateMap<Categoria, CategoriaDeletarResponse>();
            //CreateMap<Categoria, CategoriaBuscarResponse>();
        }
    }
}