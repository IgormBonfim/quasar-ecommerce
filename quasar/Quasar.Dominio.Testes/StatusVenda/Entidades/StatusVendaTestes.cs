using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Quasar.Dominio.Vendas.Entidades;
using Xunit;

namespace Quasar.Dominio.Testes.StatusVendaTestes.Entidades
{
    public class StatusVendaTestes
    {
        private readonly StatusVenda sut;

        public StatusVendaTestes()
        {
            sut = Builder<StatusVenda>.CreateNew().Build();
        }
    
        public class Construtor
        {
            [Fact]
            public void Quando_ParametrosForemValidos_Espero_ObjetoIntegro()
            {
                ///Act
                var statusVenda = new StatusVenda (
                                    "Teste de descrição"
                                    );
                ///Assert
                statusVenda.Descricao.Should().Be("Teste de descrição");
            }   
        }

        public class SetDescricaoMetodo : StatusVendaTestes
        {
            [Theory]
            [InlineData("")]
            [InlineData(" ")]
            [InlineData(null)]
            public void Dado_DescricaoNuloOuEspacoEmBranco_Espero_Exception(string descricao)
            {
                sut.Invoking(x => x.SetDescricao(new string(descricao))).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_DescricaoComMenosDeTresCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetDescricao(new string('*', 2))).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_DescricaoComMaisDeCinquentaCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetDescricao(new string('*', 51))).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_DescricaoValida_Espero_PropriedadesPreenchidas()
            {
                sut.SetDescricao("Teste de descrição");
                sut.Descricao.Should().Be("Teste de descrição");
            }
        }
    }
}