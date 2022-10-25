using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Usuarios.Entidades;
using Quasar.Dominio.Usuarios.Enumeradores;

namespace Quasar.Dominio.Usuarios.Servicos.Interfaces
{
    public interface IClientesServico
    {
        Cliente Validar(int codigo);
        Cliente Inserir(Cliente cliente);
        Cliente Instanciar(string? nome, string? nomeFantasia, string? cpfCnpj, string? inscricaoEstadual, string? razaoSocial, TipoClienteEnum? tipoCliente);
        Cliente Editar(Cliente cliente);
        void Deletar(int codigo);
    }
}