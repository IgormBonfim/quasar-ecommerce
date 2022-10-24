using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Quasar.Autenticacao.Entidades
{
    public class Usuario : IdentityUser
    {
        [Column]
        public int CodCliente { get; set; }
    }
}