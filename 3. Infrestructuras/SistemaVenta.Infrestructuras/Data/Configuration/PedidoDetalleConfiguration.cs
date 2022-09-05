using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVenta.Infraestructura.Data.Configuration
{
    public class PedidoDetalleConfiguration : IEntityTypeConfiguration<PedidoDetalle>
    {
        public void Configure(EntityTypeBuilder<PedidoDetalle> builder)
        {
            //TABLA
            builder.ToTable("PedidoDetalle");

            //CLAVE PK SQL
            builder.HasKey(e => e.Id)
                .HasName("PK_PedidoDetalle");

            //CLAVE FK SQL
            builder.HasOne(d => d.Pedido)
                .WithMany(p => p.PedidoDetalle)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("FK_PedidoDetalle_Pedido");

            builder.HasOne(d => d.Producto)
                .WithMany(p => p.PedidoDetalle)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK_PedidoDetalle_Producto");

            //CAMPOS
            builder.Property(e => e.Id)
                .HasColumnName("IdPedidoDetalle")
                .HasColumnType("int");

            builder.Property(e => e.IdPedido)
                .HasColumnName("IdPedido")
                .HasColumnType("int")
                .IsUnicode(false);

            builder.Property(e => e.IdProducto)
                .HasColumnName("IdProducto")
                .HasColumnType("int")
                .IsUnicode(false);

            builder.Property(e => e.Cantidad)
                .HasColumnName("Cantidad")
                .HasColumnType("int")
                .IsUnicode(false);

            builder.Property(e => e.MontoUnitario)
                .HasColumnName("MontoUnitario")
                .HasColumnType("decimal(17, 2)")
                .IsUnicode(false);

            builder.Property(e => e.MontoSubTotal)
                .HasColumnName("MontoSubTotal")
                .HasColumnType("decimal(17, 2)")
                .IsUnicode(false);

            builder.Property(e => e.MontoIGV)
                .HasColumnName("MontoIGV")
                .HasColumnType("decimal(17, 2)")
                .IsUnicode(false);

            builder.Property(e => e.MontoTotal)
                .HasColumnName("MontoTotal")
                .HasColumnType("decimal(17, 2)")
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
