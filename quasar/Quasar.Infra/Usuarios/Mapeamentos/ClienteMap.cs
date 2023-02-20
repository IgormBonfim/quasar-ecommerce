using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Quasar.Dominio.Usuarios.Entidades;
using Quasar.Dominio.Usuarios.Enumeradores;

namespace Quasar.Infra.Usuarios.Mapeamentos
{
    public class ClienteMap : ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Schema("railway");
            Table("cliente");
            Id(c => c.Codigo).Column("CodCliente").GeneratedBy.Identity();
            Map(c => c.Nome).Column("Nome");
            Map(c => c.NomeFantasia).Column("NomeFantasia");
            Map(c => c.CpfCnpj).Column("CpfCnpj");
            Map(c => c.InscricaoEstadual).Column("Ie");
            Map(c => c.RazaoSocial).Column("RazaoSocial");
            Map(c => c.TipoCliente).Column("Tipo").CustomType<TipoClienteEnum>();
        }
    }
}