using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Quasar.DataTransfer.Carrinhos.Responses;
using Quasar.Dominio.Carrinhos.Entidades;

namespace Quasar.Aplicacao.Carrinhos.Profiles
{
    public class CarrinhosProfile : Profile
    {
        public CarrinhosProfile()
        {
            CreateMap<Carrinho, CarrinhoInserirResponse>();
            CreateMap<Carrinho, CarrinhoEditarResponse>();
            CreateMap<Carrinho, CarrinhoResponse>();
        }
    }
}