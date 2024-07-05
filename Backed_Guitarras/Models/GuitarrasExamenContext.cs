using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backed_Guitarras.Models;

public partial class GuitarrasExamenContext : DbContext
{
    public GuitarrasExamenContext()
    {
    }

    public GuitarrasExamenContext(DbContextOptions<GuitarrasExamenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Guitarra> Guitarras { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC072D67D9E6");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Guitarra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Guitarra__3214EC07EB0DFD95");

            entity.ToTable("Guitarra");

            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");
            entity.Property(e => e.Imagen).HasMaxLength(250);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Guitarras)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("fk_Categoria");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
