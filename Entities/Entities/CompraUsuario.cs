using Entities.Entities.Enums;
using Entities.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities;

[Table("TB_COMPRA_USUARIO")]
public class CompraUsuario : Notifiers
{
    [Column("CUS_ID")]
    public int Id { get; set; }

    [Column("PRD_ID")]
    public int ProdutoId { get; set; }
    public Produto Produto { get; set; } = null!;

    [Column("CUS_ESTADO")]
    public EnumBoughtState Estado { get; set; }

    [Column("CSU_QTD")]
    public int QtdCompra { get; set; }

    [Column("USR_ID")]
    public string UserId { get; set; } = null!;

    [ForeignKey("UserId")]
    public ApplicationUser ApplicationUser { get; set; } = null!;

    [NotMapped]
    [Display(Name = "Quantidade Total")]
    public int QuantidadeProdutos { get; set; }

    [NotMapped]
    [Display(Name = "Valor Total")]
    public decimal ValorTotal { get; set; }

    [NotMapped]
    [Display(Name = "Endereço de entrega")]
    public string? EnderecoCompleto { get; set; }

    [NotMapped]
    public List<Produto>? ListaProdutos { get; set; }
}

