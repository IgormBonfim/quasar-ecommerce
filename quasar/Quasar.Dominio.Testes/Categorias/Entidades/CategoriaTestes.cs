using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Quasar.Dominio.Categorias.Entidades;
using Xunit;

namespace Quasar.Dominio.Testes.Categorias.Entidades
{
    public class CategoriaTestes
    {
        private readonly Categoria sut;
        public CategoriaTestes()
        {
            sut = Builder<Categoria>.CreateNew().Build();
        }
        public class Construtor
        {
            [Fact]
            public void Quando_ParametrosForemValidos_Espero_ObjetoIntegro()
            {
                //Arrange
                //Arc
                var categoria = new Categoria(
                    "Teste de Nome da Categoria",
                    "Teste de Imagem da Categoria"
                    );
                //Assert
                categoria.Nome.Should().Be("Teste de Nome da Categoria");
                categoria.Imagem.Should().Be("Teste de Imagem da Categoria");
            }
        }
        public class SetCodigoMetodo : CategoriaTestes
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
        public class SetNomeMetodo : CategoriaTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData(" ")]
            public void Dado_NomeNuloOuEspacoEmBranco_Espero_Exception(string nome)
            {
                sut.Invoking(x => x.SetNome(nome)).Should().Throw<Exception>();
            }
            
            [Fact]
            public void Dado_NomeComMenosDeDoisCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetNome(new string('*', 1))).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_PosicaoComMaisDeTrintaCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetNome(new string('*', 31))).Should().Throw<Exception>();
            }
            
            [Fact]
            public void Dado_ValorValido_Espero_PropriedadesPreenchidas()
            {
                sut.SetNome("Teste de Nome da Categoria");
                sut.Nome.Should().Be("Teste de Nome da Categoria");
            }

        }
        public class SetImagemMetodo : CategoriaTestes
        {
            [Theory]
            [InlineData(null)]
            public void Dado_ImagemNuloOuEspacoEmBranco_Espero_Exception(string imagem)
            {
                sut.Invoking(x => x.SetImagem(imagem)).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_ImagemComMenosDeDoisCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetImagem(new string('*', 1))).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_PosicaoComMaisDeDuzentosECinquentaESeisCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetImagem(new string('*', 256))).Should().Throw<Exception>();
            } 
            [Fact]
            public void Dado_ValorValido_Espero_PropriedadesPreenchidas()
            {
                sut.SetImagem("Teste de Imagem da Categoria");
                sut.Imagem.Should().Be("Teste de Imagem da Categoria");
            }
        }
    }
}