using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Quasar.Dominio.Ufs.Entidades;
using Xunit;

namespace Quasar.Dominio.Testes.Ufs.Entidades
{
    public class UfTestes
    {
        private readonly Uf sut;

        public UfTestes()
        {
            sut = Builder<Uf>.CreateNew().Build();
        }

        public class Construtor
        {
            [Fact]
            public void Quando_ParametrosForemValidos_Espero_ObjetoIntegro()
            {
                // Act
                var uf = new Uf("TS",
                                "Testes");
                //Assert
                uf.Sigla.Should().Be("TS");
                uf.Nome.Should().Be("Testes");
            }
        }

        public class SetSiglaMetodo : UfTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData(" ")]
            public void Dado_UfNegativa_Espero_Exception(string sigla)
            {
                sut.Invoking(x => x.SetSigla(sigla)).Should().Throw<Exception>();
            }
            [Fact]
            public void Dado_UfComUmaLetra_Espero_Exception()
            {
                sut.Invoking(x => x.SetSigla(new string('*', 1))).Should().Throw<Exception>();
            }
            [Fact]
            public void Dado_UfComTresLetras_Espero_Exception()
            {
                sut.Invoking(x => x.SetSigla(new string('*', 3))).Should().Throw<Exception>();
            }
        }

        public class SetCodigoMetodo : UfTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData(-1)]
            [InlineData(0)]
            public void Dado_ValorNulloOuMenorQueUm_Espero_Exception(int codigo)
            {
                sut.Invoking(x => x.SetCodigo(codigo)).Should().Throw<Exception>();
            }
            [Fact]
            public void Dado_ValorValido_Espero_PropriedadesPreenchidas()
            {
                sut.SetCodigo(1);
                sut.Codigo.Should().Be(1);
            }
        }
        public class SetNomeMetodo : UfTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData(" ")]
            public void Dado_UfNegativa_Espero_Exception(string nome)
            {
                sut.Invoking(x => x.SetNome(nome)).Should().Throw<Exception>();
            }
            [Fact]
            public void Dado_NomeDaUfComDuasLetra_Espero_Exception()
            {
                sut.Invoking(x => x.SetNome(new string('*', 2))).Should().Throw<Exception>();
            }
        }
    }
}