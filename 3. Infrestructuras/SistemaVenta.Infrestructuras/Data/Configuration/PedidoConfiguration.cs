using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVenta.Infraestructura.Data.Configuration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            //TABLA
            builder.ToTable("Pedido");

            //CLAVE PK SQL
            builder.HasKey(e => e.Id)
                .HasName("PK_Pedido");

            //CLAVE FK SQL
            builder.HasOne(d => d.Cliente)
                .WithMany(p => p.Pedido)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_Pedido_Cliente");

            //CAMPOS
            builder.Property(e => e.IdCliente)
                .HasColumnName("IdCliente")
                .HasColumnType("int");

            builder.Property(e => e.CodigoPedido)
                 .HasColumnName("CodigoPedido")
                 .HasColumnType("varchar(15)")
                 .IsUnicode(false);

            builder.Property(e => e.MontoSubTotal)
                 .HasColumnName("MontoSubTotal")
                 .HasColumnType("decimal(18, 2))")
                 .IsUnicode(false);

            builder.Property(e => e.MontoIgv)
                 .HasColumnName("MontoIGV")
                 .HasColumnType("decimal(18, 2))")
                 .IsUnicode(false);

            builder.Property(e => e.MontoTotal)
                 .HasColumnName("MontoTotal")
                 .HasColumnType("decimal(18, 2))")
                 .IsUnicode(false);

            builder.Property(e => e.Descripcion)
                 .HasColumnName("Descripcion")
                 .HasColumnType("varchar(150)")
                 .IsUnicode(false);

            builder.Property(e => e.EstadoPedido)
                 .HasColumnName("EstadoPedido")
                 .HasColumnType("varchar(500)")
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
