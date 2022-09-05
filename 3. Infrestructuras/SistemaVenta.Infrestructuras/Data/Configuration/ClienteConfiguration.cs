using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Core.Entities;
using System;

namespace SistemaVenta.Infraestructura.Data.Configuration
{
    public class ClienteConfiguration: IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            //TALBLA
            builder.ToTable("Cliente");

            //CLAVE PK SQL
            builder.HasKey(e => e.Id)
                .HasName("PK_Cliente");

            //CAMPOS
            builder.Property(e => e.Id)
                .HasColumnName("IdCliente")
                .HasColumnType("int");

            builder.Property(e => e.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("varchar(150)")
                .IsUnicode(false);

            builder.Property(e => e.ApellidoPaterno)
                .HasColumnName("ApellidoPaterno")
                .HasColumnType("varchar(150)")
                .IsUnicode(false);

            builder.Property(e => e.ApallidoMaterno)
                .HasColumnName("ApallidoMaterno")
                .HasColumnType("varchar(150)")
                .IsUnicode(false);

            builder.Property(e => e.RazonSocial)
                .HasColumnName("RazonSocial")
                .HasColumnType("varchar(250)")
                .IsUnicode(false);

            builder.Property(e => e.IdTipoDocumento)
                .HasColumnName("IdTipoDocumento")
                .HasColumnType("int")
                .IsUnicode(false);

            builder.Property(e => e.NumeroDocumento)
                .HasColumnName("NumeroDocumento")
                .HasColumnType("varchar(15)")
                .IsUnicode(false);

            builder.Property(e => e.FechaNacimiento)
                .HasColumnName("FechaNacimiento")
                .HasColumnType("datetime")
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
