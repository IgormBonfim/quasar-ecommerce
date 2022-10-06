using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.Dominio.Categorias.Entidades
{
    public class Categoria
    {
        public virtual int IdCategoria {get; protected set;}
        public virtual string NomeCategoria{get; protected set;}
        public virtual string ImgCategoria{get; protected set;}
        public Categoria (){ }
        public Categoria(string nomeCategoria, string imgCategoria)
        {
            SetNomeCategoria(nomeCategoria);
            SetImgCategoria(imgCategoria); 
        }
        
        public virtual void SetIdCategoria(int? idCategoria)
        {
            if(!idCategoria.HasValue)
            {
                throw new Exception("Código da categoria é obrigatório!");
            }
            IdCategoria = idCategoria.Value;
        }

        public virtual void SetNomeCategoria(string nomeCategoria)
        {
            if(string.IsNullOrWhiteSpace(nomeCategoria) && nomeCategoria.Length < 2)
                throw new Exception ("o campo nome deve possuir minimo 2 caracteres");
            if(nomeCategoria.Length > 30)
                throw new Exception("o campo nome deve possuir maximo 30 caracteres");
            NomeCategoria = nomeCategoria;
        }

        public virtual void SetImgCategoria(string imgCategoria)
        {
            ImgCategoria = imgCategoria;
        }

    }



}