using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NeitekWS.Models;

public partial class NeitekContext : DbContext
{
    public NeitekContext()
    {
    }

    public NeitekContext(DbContextOptions<NeitekContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Meta> Metas { get; set; }

    public virtual DbSet<MetasView> MetasViews { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Meta>(entity =>
        {
            entity.HasKey(e => e.PkMeta);

            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MetasView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("MetasView");

            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Porcentaje).HasColumnType("decimal(5, 3)");
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.PkTarea);

            entity.Property(e => e.NombreTarea)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
