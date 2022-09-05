using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVenta.Infraestructura.Data.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            //TABLA
            builder.ToTable("Producto");

            //CLAVE PK SQL
            builder.HasKey(e => e.Id)
                .HasName("PK_Productos");

            //CAMPOS
            builder.Property(e => e.Id)
                .HasColumnName("IdProducto")
                .HasColumnType("int");


            builder.Property(e => e.CodigoProducto)
                .HasColumnName("CodigoProducto")
                .HasColumnType("varchar(15)")
                .IsUnicode(false);

            builder.Property(e => e.NombreProducto)
                .HasColumnName("NombreProducto")
                .HasColumnType("varchar(150)")
                .IsUnicode(false);

            builder.Property(e => e.Descripcion)
                .HasColumnName("Descripcion")
                .HasColumnType("varchar(250)")
                .IsUnicode(false);

            builder.Property(e => e.Imagen)
                .HasColumnName("Imagen")
                .HasColumnType("varchar(250)")
                .IsUnicode(false);

            builder.Property(e => e.IndActivo)
                .HasColumnName("IndActivo")
                .HasColumnType("bit")
                .HasDefaultValue(true)
                .IsUnicode(false);

            builder.Property(e => e.IdUsuarioRegistro)
                .HasColumnName("IdUsuarioRegistro")
                .HasColumnType("int")
                .HasDefaultValue(0)
                .IsUnicode(false);

            builder.Property(e => e.FechaRegistro)
                .HasColumnName("FechaRegistro")
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now)
                .IsUnicode(false);

            builder.Property(e => e.IdUsuarioModificacion)
               .HasColumnName("IdUsuarioModificacion")
               .HasColumnType("int")
               .HasDefaultValue(0)
               .IsUnicode(false);

            builder.Property(e => e.FechaModificacion)
                .HasColumnName("FechaModificacion")
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now)
                .IsUnicode(false);

        }
    }
}
