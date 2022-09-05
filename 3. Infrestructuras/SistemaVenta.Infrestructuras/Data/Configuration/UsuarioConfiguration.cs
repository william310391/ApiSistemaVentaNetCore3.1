using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Core.Entities;
using System;

namespace SistemaVenta.Infraestructura.Data.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //TALBLA
            builder.ToTable("Usuario");

            //CLAVE PK SQL
            builder.HasKey(e => e.Id)
                .HasName("PK_Usuarios");

            //CAMPOS
            builder.Property(e => e.Id)
                .HasColumnName("IdUsuario")
                .HasColumnType("int");

            builder.Property(e => e.Cuenta)
                .HasColumnName("Cuenta")
                .HasColumnType("varchar(150)")
                .IsUnicode(false); 

            builder.Property(e => e.Contrasena)
                .HasColumnName("Contrasena")
                .HasColumnType("varchar(50)")
                .IsUnicode(false);

            builder.Property(e => e.NombreUsuario)
                .HasColumnName("NombreUsuario")
                .HasColumnType("varchar(250)")
                .IsUnicode(false);

            builder.Property(e => e.IdRol)
                .HasColumnName("IdRol")
                .HasColumnType("int")
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
