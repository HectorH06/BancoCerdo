using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PiggyBank.Models;

[Table("rifa")]
public partial class Rifa
{
    [Key]
    [Column("No_Boleto")]
    public long NoBoleto { get; set; }

    [Column(TypeName = "INT")]
    public long Cuenta { get; set; }

    [Column("Fecha_Boleto", TypeName = "datetime")]
    public byte[] FechaBoleto { get; set; } = null!;

    [ForeignKey("Cuenta")]
    [InverseProperty("Rifas")]
    public virtual Cuentum CuentaNavigation { get; set; } = null!;
}
