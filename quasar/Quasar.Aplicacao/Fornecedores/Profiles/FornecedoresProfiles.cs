using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Quasar.DataTransfer.Fornecedores.Responses;
using Quasar.Dominio.Fornecedores.Entidades;

namespace Quasar.Aplicacao.Fornecedores.Profiles
{
    public class FornecedoresProfiles : Profile
    {
        public FornecedoresProfiles()
        {
            CreateMap<Fornecedor, FornecedorResponse>();
            CreateMap<Fornecedor, FornecedorEditarResponse>();
            CreateMap<Fornecedor, FornecedorInserirResponse>();
        }
    }
}