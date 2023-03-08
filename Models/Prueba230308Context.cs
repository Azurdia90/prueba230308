using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prueba230308.Models;

public partial class Prueba230308Context : DbContext
{
    public Prueba230308Context()
    {
    }

    public Prueba230308Context(DbContextOptions<Prueba230308Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //   => optionsBuilder.UseSqlServer("server=localhost;database=PRUEBA230308;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__producto__3213E83FD45140ED");

            entity.ToTable("producto");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("money")
                .HasColumnName("precio");
            entity.Property(e => e.UnidadMedida)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("unidad_medida");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
