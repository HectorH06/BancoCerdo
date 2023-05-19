using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PiggyBank.Models;

[Table("prestamo")]
public partial class Prestamo
{
    [Key]
    [Column(TypeName = "INT")]
    public long Folio { get; set; }

    [Column(TypeName = "pesos")]
    public byte[] Cantidad { get; set; } = null!;

    [Column(TypeName = "float")]
    public double Interes { get; set; }

    [InverseProperty("FolioNavigation")]
    public virtual ICollection<DatosPrestamo> DatosPrestamos { get; set; } = new List<DatosPrestamo>();

    [InverseProperty("FolioNavigation")]
    public virtual ICollection<EstadoPrestamo> EstadoPrestamos { get; set; } = new List<EstadoPrestamo>();
}
