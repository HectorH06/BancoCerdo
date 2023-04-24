using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PiggyBank.Models;

[Table("info_Cuenta")]
public partial class InfoCuentum
{
    [Key]
    public long NoUsuario { get; set; }

    [Column("No_Cuenta", TypeName = "INT")]
    public long NoCuenta { get; set; }

    [Column(TypeName = "pesos")]
    public byte[] Saldo { get; set; } = null!;

    [Column(TypeName = "INT")]
    public long Estado { get; set; }

    [ForeignKey("NoCuenta")]
    [InverseProperty("InfoCuenta")]
    public virtual Cuentum NoCuentaNavigation { get; set; } = null!;
}
