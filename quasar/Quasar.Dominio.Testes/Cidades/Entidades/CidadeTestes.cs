using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Quasar.Dominio.Cidades.Entidades;
using Quasar.Dominio.Ufs.Entidades;
using Xunit;

namespace Quasar.Dominio.Testes.Cidades.Entidades
{
    public class CidadeTestes
    {
        private readonly Cidade sut;
        public CidadeTestes()
        {
            sut = Builder<Cidade>.CreateNew().Build();
        }

        public class Construtor
        {
            [Fact]
            public void Quando_ParametrosForemValidos_Espero_ObjetoIntegro()
            {
                // Arrange
                var uf = Builder<Uf>.CreateNew().Build();
                
                //Act
                var cidade = new Cidade(
                                "Nome de uma cidade",
                                uf);
                
                
                //Assert
                cidade.Nome.Should().Be("Nome de uma cidade");
                cidade.Uf.Should().BeSameAs(uf);
            }
        }

        public class SetCodigoMetodo : CidadeTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData(-1)]
            [InlineData(0)]
            public void Dado_ValorNulloOuMenorQueUm_Espero_Exception(int valor)
            {
                sut.Invoking(x => x.SetCodigo(valor)).Should().Throw<Exception>();
            }
            [Fact]
            public void Dado_ValorValido_Espero_PropriedadesPreenchidas()
            {
                sut.SetCodigo(1);
                sut.Codigo.Should().Be(1);
            }
        }

        public class SetNomeMetodo : CidadeTestes
        {
            [Theory]
            [InlineData("")]
            [InlineData(" ")]
            [InlineData(null)]
            public void Dado_NomeNuloOuEspacoEmBranco_Espero_Exception(string nome)
            {
                sut.Invoking(x => x.SetNome(new string(nome))).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_NomeComMenosDeTresCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetNome(new string('*', 2))).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_NomeComMaisDeCemCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetNome(new string('*', 101))).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_CidadeValido_Espero_PropriedadesPreenchidas()
            {
                sut.SetNome("Nome de uma cidade");
                sut.Nome.Should().Be("Nome de uma cidade");
            }
            public class SetUfMetodo : CidadeTestes
            {
                [Theory]
                [InlineData(null)]
                public void Quando_UfForNulo_Espero_Exception(Uf uf)
                {
                    sut.Invoking(x => x.SetUf(uf)).Should().Throw<Exception>();
                }

                [Fact]
                public void Quando_UfForValido_Espero_PropriedadePreenchida()
                {
                    var uf = Builder<Uf>.CreateNew().Build();
                    sut.SetUf(uf);
                    sut.Uf.Should().BeSameAs(uf);
                }
            }
        }
    }
}