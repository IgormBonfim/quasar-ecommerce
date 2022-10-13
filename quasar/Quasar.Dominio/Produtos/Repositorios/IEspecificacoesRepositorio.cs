using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Produtos.Entidades;

namespace Quasar.Dominio.Produtos.Repositorios
{
    public interface IEspecificacoesRepositorio
    {
        Especificacao Inserir (Especificacao especificacao);
        Especificacao Editar (Especificacao especificacao);
        void Deletar (Especificacao especificacao);
        Especificacao Recuperar (int cod);
        IQueryable<Especificacao> Query();
    }
}