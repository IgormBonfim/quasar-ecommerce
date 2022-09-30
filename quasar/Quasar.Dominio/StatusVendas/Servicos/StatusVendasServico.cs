using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.StatusVendas.Entidades;
using Quasar.Dominio.StatusVendas.Repositorios;
using Quasar.Dominio.StatusVendas.Servicos.Interfaces;

namespace Quasar.Dominio.StatusVendas.Servicos
{
    public class StatusVendasServico : IStatusVendasServico
    {
        private readonly IStatusVendasRepositorio statusVendasRepositorio;
        public StatusVendasServico(IStatusVendasRepositorio statusVendasRepositorio)
        {
            this.statusVendasRepositorio = statusVendasRepositorio;
        }
        public StatusVenda Validar(int id)
        {
            StatusVenda statusVendaValidar = statusVendasRepositorio.Recuperar(id);
            if (statusVendaValidar == null)
                throw new Exception("Status da venda não identificado.");
            return statusVendaValidar;
        }
    }
}