using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PiggyBank.Models;

[Table("cuenta")]
public partial class Cuentum
{
    [Key]
    [Column("No_Cuenta", TypeName = "INT")]
    public long NoCuenta { get; set; }

    [Column(TypeName = "varchar(16)")]
    public string? Password { get; set; }

    [Column("Tipo_Cuenta", TypeName = "tinyint")]
    public long TipoCuenta { get; set; }

    [InverseProperty("SolicitadoPorNavigation")]
    public virtual ICollection<DatosPrestamo> DatosPrestamos { get; set; } = new List<DatosPrestamo>();

    [InverseProperty("NoCuentaNavigation")]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    [InverseProperty("NoCuentaNavigation")]
    public virtual ICollection<InfoCuentum> InfoCuenta { get; set; } = new List<InfoCuentum>();

    [InverseProperty("CuentaNavigation")]
    public virtual ICollection<Rifa> Rifas { get; set; } = new List<Rifa>();

    [InverseProperty("NoCuentaNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
