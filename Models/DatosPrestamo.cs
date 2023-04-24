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
    public byte[] FechaExpedicion { get; set; } = null!;

    [Column("Fecha_Aprobacion", TypeName = "datetime")]
    public byte[] FechaAprobacion { get; set; } = null!;

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
