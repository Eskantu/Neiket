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

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.PkTarea);

            entity.Property(e => e.NombreTarea)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.HasOne(d => d.FkMetaNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.FkMeta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tareas_Tareas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
