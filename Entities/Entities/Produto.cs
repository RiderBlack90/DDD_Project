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

[Table("Product")]
public class Produto : Notifiers
{
    [Column("PRD_ID")]
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Column("PRD_NOME")]
    [Display(Name = "Nome")]
    [MaxLength(255)]
    public string? Nome { get; set; }
    [Column("PRD_DSC")]
    [Display(Name = "Descrição")]
    [MaxLength(255)]
    public string? Descricao { get; set; }
    [Column("PRD_OBS")]
    [Display(Name = "Observação")]
    [MaxLength(20000)]
    public string? Observacao { get; set; }

    [Column("PRD_VAL")]
    [Display(Name = "Valor")]
    public decimal Valor { get; set; }

    [Column("PRD_QTD_ESTOQUE")]
    [Display(Name = "Quantidade Estoque")]
    public int QtdEstoque { get; set; }

    [Display(Name = "Usuário")]
    [ForeignKey("ApplicationUser")]
    [Column(Order = 1)]
    public string? UserId { get; set; }

    public virtual ApplicationUser ApplicationUser { get; set; }


    [Column("PRD_ESTADO")]
    [Display(Name = "Estado")]
    public bool Estado { get; set; }

}
