using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.Dominio.Categorias.Entidades
{
    public class Categoria
    {
        public virtual int Codigo {get; protected set;}
        public virtual string Nome {get; protected set;}
        public virtual string Imagem {get; protected set;}
        public Categoria (){ }
        public Categoria(string nome, string imagem)
        {
            SetNome(nome);
            SetImagem(imagem); 
        }
        
        public virtual void SetCodigo(int? codigo)
        {
            if(!codigo.HasValue)
            {
                throw new Exception("Código da categoria é obrigatório!");
            }
            Codigo = codigo.Value;
        }

        public virtual void SetNome(string nome)
        {
            if(string.IsNullOrWhiteSpace(nome) && nome.Length < 2)
                throw new Exception ("o campo nome deve possuir minimo 2 caracteres");
            if(nome.Length > 30)
                throw new Exception("o campo nome deve possuir maximo 30 caracteres");
            Nome = nome;
        }

        public virtual void SetImagem(string imagem)
        {
            if(string.IsNullOrWhiteSpace(imagem) && imagem.Length < 2)
                throw new Exception ("o campo imagem deve possuir minimo 2 caracteres");
            if(imagem.Length > 255)
                throw new Exception("o campo imagem deve possuir maximo 255 caracteres");
            Imagem = imagem;
        }

    }



}