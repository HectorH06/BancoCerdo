using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PiggyBank.Models;

[Table("usuario")]
public partial class Usuario
{
    [Key]
    [Column("CURP", TypeName = "varchar(19)")]
    
    public string Curp { get; set; } = null!;

    [Column("Nombre(s)", TypeName = "varchar(30)")]
    
    public string NombreS { get; set; } = null!;

    [Column("Apellido_Paterno", TypeName = "varchar(30)")]
    
    public string ApellidoPaterno { get; set; } = null!;

    [Column("Apellido_Materno", TypeName = "varchar(30)")]
    
    public string ApellidoMaterno { get; set; } = null!;

    [Column("Fecha de Nacimiento", TypeName = "datetime")]
    public DateTime FechaDeNacimiento { get; set; }

    [Column("No_Cuenta", TypeName = "INT")]
    public long? NoCuenta { get; set; }

    [ForeignKey("NoCuenta")]
    [InverseProperty("Usuarios")]
    public virtual Cuentum? NoCuentaNavigation { get; set; }
}
