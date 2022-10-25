using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Cidades.Entidades;
using Quasar.Dominio.Usuarios.Entidades;

namespace Quasar.Dominio.Enderecos.Entidades
{
    public class Endereco
    {
        public virtual int Codigo { get; protected set; }
        public virtual int Numero { get; protected set; }
        public virtual string Bairro { get; protected set; }
        public virtual string Rua { get; protected set; }
        public virtual string PontoReferencia { get; protected set; }
        public virtual string Complemento { get; protected set; }
        public virtual string Cep { get; protected set; }
        public virtual Cidade Cidade{ get; protected set; }
        public virtual Usuario Usuario{ get; protected set; }
        public Endereco(){
        }

        public Endereco (int? numero, string? bairro, string? rua, string? pontoReferencia, string? complemento, string? cep, Cidade cidade, Usuario usuario)
        {
            SetNumero(numero);
            SetBairro(bairro);
            SetRua(rua);
            SetPontoReferencia(pontoReferencia);
            SetComplemento(complemento);
            SetCep(cep);
            SetCidade(cidade);
            SetUsuario(usuario);
        }

        public virtual void SetCodigo(int? codigo)
        {
            if(!codigo.HasValue)
            {
                throw new Exception("Código do endereco é obrigatório!");
            }
            Codigo = codigo.Value;
        }

        // não sei como setar numero
        public virtual void SetNumero(int? numero)
        {
            if(!numero.HasValue)
            {
                throw new Exception("Numero de Endereço é obrigatório!");
            }
            Numero = numero.Value;
        }

        public virtual void SetBairro(string? bairro)
        {
            if(string.IsNullOrWhiteSpace(bairro) || bairro.Length < 2)
                throw new Exception("O campo bairro deve possuir ao menos 2 caracteres!");

            if(bairro.Length > 100)
                throw new Exception("O campo bairro deve possuir até 100 caracteres!");

            Bairro = bairro;
        }

        public virtual void SetRua(string? rua)
        {
            if(string.IsNullOrWhiteSpace(rua) || rua.Length < 2)
                throw new Exception("O campo rua deve possuir ao menos 2 caracteres!");

            if(rua.Length > 100)
                throw new Exception("O campo rua deve possuir até 100 caracteres!");

            Rua = rua;
        }
        public virtual void SetPontoReferencia(string? pontoReferencia)
        {
            if(string.IsNullOrWhiteSpace(pontoReferencia) || pontoReferencia.Length < 2)
                throw new Exception("O campo pontoReferencia deve possuir ao menos 2 caracteres!");

            if(pontoReferencia.Length > 100)
                throw new Exception("O campo pontoReferencia deve possuir até 100 caracteres!");

            PontoReferencia = pontoReferencia;
        }

        public virtual void SetComplemento(string? complemento)
        {
            if(string.IsNullOrWhiteSpace(complemento) || complemento.Length < 2)
                throw new Exception("O campo complemento deve possuir ao menos 2 caracteres!");

            if(complemento.Length > 100)
                throw new Exception("O campo complemento deve possuir até 100 caracteres!");

            Complemento = complemento;
        }

        public virtual void SetCep(string? cep)
        {
            if(string.IsNullOrWhiteSpace(cep) || cep.Length < 2)
                throw new Exception("O campo cep deve possuir ao menos 2 caracteres!");

            if(cep.Length > 8)
                throw new Exception("O campo cep deve possuir até 8 caracteres!");

            Cep = cep;
        }

        public virtual void SetCidade(Cidade cidade)
        {
            if(cidade == null)
            throw new Exception("O campo cidade é obrigatório!");
            Cidade = cidade;
        }
        public virtual void SetUsuario(Usuario usuario)
        {
            if(usuario == null)
            throw new Exception ("O campo usuario é obrigatório!");
            Usuario = usuario;
        }
    }
}
