using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Vendas.Entidades;
using Quasar.Dominio.Vendas.Repositorios;
using Quasar.Dominio.Vendas.Servicos.Interfaces;

namespace Quasar.Dominio.Vendas.Servicos
{
    public class StatusVendasServico : IStatusVendasServico
    {
        private readonly IStatusVendasRepositorio statusVendasRepositorio;
        public StatusVendasServico(IStatusVendasRepositorio statusVendasRepositorio)
        {
            this.statusVendasRepositorio = statusVendasRepositorio;
        }
        public StatusVenda Validar(int codigo)
        {
            StatusVenda statusVendaValidar = statusVendasRepositorio.Recuperar(codigo);
            if (statusVendaValidar == null)
                throw new Exception("Status da venda não identificado.");
            return statusVendaValidar;
        }
    }
}