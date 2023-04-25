using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PiggyBank.Models;

public partial class PiggyDatabase : DbContext
{
    public PiggyDatabase()
    {
    }

    public PiggyDatabase(DbContextOptions<PiggyDatabase> options)
        : base(options)
    {
    }

    public virtual DbSet<Cuentum> Cuentas { get; set; }

    public virtual DbSet<DatosPrestamo> DatosPrestamos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<EstadoPrestamo> EstadoPrestamos { get; set; }

    public virtual DbSet<Gerente> Gerentes { get; set; }

    public virtual DbSet<InfoCuentum> InfoCuentas { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Rifa> Rifas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Filename=PiggyDatabase.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cuentum>(entity =>
        {
            entity.Property(e => e.NoCuenta).ValueGeneratedNever();
        });

        modelBuilder.Entity<DatosPrestamo>(entity =>
        {
            entity.HasOne(d => d.FolioNavigation).WithMany(p => p.DatosPrestamos).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.SolicitadoPorNavigation).WithMany(p => p.DatosPrestamos).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.Property(e => e.Nomina).ValueGeneratedNever();
        });

        modelBuilder.Entity<EstadoPrestamo>(entity =>
        {
            entity.HasOne(d => d.FolioNavigation).WithMany(p => p.EstadoPrestamos).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Gerente>(entity =>
        {
            entity.HasOne(d => d.NominaNavigation).WithMany(p => p.Gerentes).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<InfoCuentum>(entity =>
        {
            entity.Property(e => e.Saldo).HasDefaultValueSql("10000");

            entity.HasOne(d => d.NoCuentaNavigation).WithMany(p => p.InfoCuenta).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.Property(e => e.Folio).ValueGeneratedNever();
        });

        modelBuilder.Entity<Rifa>(entity =>
        {
            entity.HasOne(d => d.CuentaNavigation).WithMany(p => p.Rifas).OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
