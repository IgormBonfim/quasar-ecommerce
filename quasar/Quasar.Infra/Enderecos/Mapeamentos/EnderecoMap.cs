using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Quasar.Dominio.Enderecos.Entidades;

namespace Quasar.Infra.Enderecos.Mapeamentos
{
    public class EnderecoMap : ClassMap<Endereco>
    {
        public EnderecoMap()
        {
            Schema("railway");
            Table("endereco");
            Id(e => e.Codigo).Column("codEndereco").GeneratedBy.Identity();
            Map(e => e.Numero).Column("numero");
            Map(e => e.Bairro).Column("bairro");
            Map(e => e.Rua).Column("rua");
            Map(e => e.PontoReferencia).Column("pontoReferencia");
            Map(e => e.Complemento).Column("complemento");
            Map(e => e.Cep).Column("cep");
            References(e => e.Cidade).Column("codCidade");
            References(e => e.Usuario).Column("codUsuario");
        }
    }
}