using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PiggyBank.Models;

[Table("datos_prestamo")]
public partial class DatosPrestamo
{
    [Key]
    [Column("NFolio")]
    public long Nfolio { get; set; }

    [Column("Fecha_Expedicion", TypeName = "datetime")]
    public DateTime FechaExpedicion { get; set; }

    [Column("Fecha_Aprobacion", TypeName = "datetime")]
    public DateTime FechaAprobacion { get; set; }

    [Column(TypeName = "INT")]
    public long Folio { get; set; }

    [Column("Solicitado_Por", TypeName = "INT")]
    public long SolicitadoPor { get; set; }

    [ForeignKey("Folio")]
    [InverseProperty("DatosPrestamos")]
    public virtual Prestamo FolioNavigation { get; set; } = null!;

    [ForeignKey("SolicitadoPor")]
    [InverseProperty("DatosPrestamos")]
    public virtual Cuentum SolicitadoPorNavigation { get; set; } = null!;
}
