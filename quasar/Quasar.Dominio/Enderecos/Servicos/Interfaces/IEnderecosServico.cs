using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Enderecos.Entidades;

namespace Quasar.Dominio.Enderecos.Servicos.Interfaces
{
    public interface IEnderecosServico
    {
        Endereco Validar (int codigo);
        Endereco Inserir (Endereco endereco);
        Endereco Instanciar (int numero, string bairro, string rua, string pontoReferencia, string complemento, string cep, int codCidade, string codUsuario);
        Endereco Editar (Endereco endereco);
        void Deletar (int codigo);
    }
}                                                                       