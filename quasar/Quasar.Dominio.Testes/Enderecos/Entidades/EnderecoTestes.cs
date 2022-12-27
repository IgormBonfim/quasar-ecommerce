using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Quasar.Dominio.Cidades.Entidades;
using Quasar.Dominio.Enderecos.Entidades;
using Quasar.Dominio.Usuarios.Entidades;
using Xunit;

namespace Quasar.Dominio.Testes.Enderecos.Entidades
{
    public class EnderecoTestes
    {
        private readonly Endereco sut;

        public EnderecoTestes()
        {
            sut = Builder<Endereco>.CreateNew().Build();
        }

        public class Constructor
        {
            [Fact]
            public void Quando_ParametrosForemValidos_Espero_ObjetoIntegro()
            {
                //Arrange
                var cidade = Builder<Cidade>.CreateNew().Build();
                var usuario = Builder <Usuario>.CreateNew().Build();

                //Act
                var endereco = new Endereco (
                    21,
                    "Teste de nome do bairro",
                    "Teste de nome da rua",
                    "Teste de ponto de referencia",
                    "Teste de complemento",
                    "25101493",
                    cidade,
                    usuario);

                //Assert
                endereco.Numero.Should().Be(21);
                endereco.Bairro.Should().Be("Teste de nome do bairro");
                endereco.Rua.Should().Be("Teste de nome da rua");
                endereco.PontoReferencia.Should().Be("Teste de ponto de referencia");
                endereco.Complemento.Should().Be("Teste de complemento");
                endereco.Cep.Should().Be("25101493");
                endereco.Cidade.Should().BeSameAs(cidade);
                endereco.Usuario.Should().BeSameAs(usuario);
            }
        }
        public class SetCodigo : EnderecoTestes
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
        public class SetNumero : EnderecoTestes
        {
            
            [Fact]
            public void Dado_NumeroNegativa_Espero_Exception()
            {
                sut.Invoking(x => x.SetNumero(-1)).Should().Throw<Exception>();
            }
            [Fact]
            public void Dado_NumeroZero_Espero_Exception()
            {
                sut.Invoking(x => x.SetNumero(null)).Should().Throw<Exception>();
            }
            public void Dado_ValorValido_Espero_PropriedadesPreenchidas()
            {
                sut.SetNumero(21);
                sut.Numero.Should().Be(21);
            }
        }
        public class SetBairro : EnderecoTestes
        {
            
            public void Dado_BairroComMenosDeDoisCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetBairro(new string('*', 1))).Should().Throw<Exception>();
            }
            public void Dado_BairroComMaisDeCemCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetBairro(new string('*', 99))).Should().Throw<Exception>();
            }
            public void Dado_ValorValido_Espero_PropriedadesPreenchidas()
            {
                sut.SetBairro("Teste de nome do bairro");
                sut.Bairro.Should().Be("Teste de nome do bairro");
            }
        }
        public class SetRua : EnderecoTestes
        {
            
            public void Dado_RuaComMenosDeDoisCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetRua(new string('*', 1))).Should().Throw<Exception>();
            }
            public void Dado_RuaComMaisDeCemCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetRua(new string('*', 99))).Should().Throw<Exception>();
            }
            public void Dado_ValorValido_Espero_PropriedadesPreenchidas()
            {
                sut.SetRua("Teste de nome do rua");
                sut.Rua.Should().Be("Teste de nome do rua");
            }
        }
        public class SetPontoReferencia : EnderecoTestes
        {
            
            public void Dado_PontoReferenciaComMenosDeDoisCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetPontoReferencia(new string('*', 1))).Should().Throw<Exception>();
            }
            public void Dado_PontoDeReferenciaComMaisDeCemCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetPontoReferencia(new string('*', 99))).Should().Throw<Exception>();
            }
            public void Dado_ValorValido_Espero_PropriedadesPreenchidas()
            {
                sut.SetPontoReferencia("Teste de ponto de referencia");
                sut.PontoReferencia.Should().Be("Teste de ponto de referencia");
            }
        }
        public class SetComplemento : EnderecoTestes
        {
            
            public void Dado_ComplementoComMenosDeDoisCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetComplemento(new string('*', 1))).Should().Throw<Exception>();
            }
            public void Dado_ComplementoComMaisDeCemCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetComplemento(new string('*', 99))).Should().Throw<Exception>();
            }
            public void Dado_ValorValido_Espero_PropriedadesPreenchidas()
            {
                sut.SetComplemento("Teste de nome do complemento");
                sut.Complemento.Should().Be("Teste de nome do complemento");
            }
        }
        public class SetCep : EnderecoTestes
        {
            
            public void Dado_CepComMenosDeDoisCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetCep(new string('*', 1))).Should().Throw<Exception>();
            }
            public void Dado_CepComMaisDeOitoCaracteres_Espero_Exception()
            {
                sut.Invoking(x => x.SetCep(new string('*', 7))).Should().Throw<Exception>();
            }
            public void Dado_ValorValido_Espero_PropriedadesPreenchidas()
            {
                sut.SetCep("25101493");
                sut.Cep.Should().Be("25101493");
            }
        }
        public class SetCidade : EnderecoTestes
        {
            [Theory]
            [InlineData(null)]
            public void Quando_CidadeForNulo_Espero_Exception(Cidade Cidade)
            {
                sut.Invoking(x => x.SetCidade(Cidade)).Should().Throw<Exception>();
            }

            [Fact]
            public void Quando_CidadeForValido_Espero_PropriedadePreenchida()
            {
                var Cidade = Builder<Cidade>.CreateNew().Build();
                sut.SetCidade(Cidade);
                sut.Cidade.Should().BeSameAs(Cidade);
            }
        }
        public class SetUsuario : EnderecoTestes
        {
            [Theory]
            [InlineData(null)]
            public void Quando_UsuarioForNulo_Espero_Exception(Usuario Usuario)
            {
                sut.Invoking(x => x.SetUsuario(Usuario)).Should().Throw<Exception>();
            }

            [Fact]
            public void Quando_UsuarioForValido_Espero_PropriedadePreenchida()
            {
                var Usuario = Builder<Usuario>.CreateNew().Build();
                sut.SetUsuario(Usuario);
                sut.Usuario.Should().BeSameAs(Usuario);
            }
        }
    }
}