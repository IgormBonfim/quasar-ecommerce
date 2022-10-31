using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Quasar.DataTransfer.Produtos.Responses;
using Quasar.Dominio.Produtos.Entidades;

namespace Quasar.Aplicacao.Produtos.Profiles
{
    public class EspecificacaoProfile : Profile
    {
        public EspecificacaoProfile()
        {
            CreateMap<Especificacao, EspecificacaoResponse>();
        }
    }
}