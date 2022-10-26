using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Genericos.Entidades;

namespace Quasar.Dominio.Genericos
{
    public interface IGenericosRepositorio<T> where T : class
    {
        int Inserir(T objeto);
        T Editar(T objeto);
        void Deletar(T objeto);
        T Recuperar(int codigo);
        IQueryable<T> Query();
        ListaPaginada<T> Listar(IQueryable<T> query, int qt, int pagina);
    }
}