using Entities.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities;

public class ApplicationUser : IdentityUser
{
    [MaxLength(14)]
    public int CPF { get; set; }
    public int Idade { get; set; }

    [MaxLength(100)]
    public string? Nome { get; set; }

    [MaxLength(9)]
    public string? CEP { get; set; } 

    [MaxLength(100)]
    public string? Endereco { get; set; }

    [MaxLength(100)]
    public string? CompEndereco { get; set; }

    [MaxLength(20)]
    public int Telefone { get; set; }

    public bool Estado { get; set; } // ativo/inativo

    public TypeUser? Tipo { get; set; }
}
