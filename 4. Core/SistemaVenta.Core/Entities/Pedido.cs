using System;
using System.Collections.Generic;

namespace SistemaVenta.Core.Entities
{
    public partial class Pedido: BaseEntity
    {
        public Pedido()
        {
            PedidoDetalle = new HashSet<PedidoDetalle>();
        }
        public int? IdCliente { get; set; }
        public string CodigoPedido { get; set; }
        public int? MontoSubTotal { get; set; }
        public decimal? MontoIgv { get; set; }
        public decimal? MontoTotal { get; set; }
        public string Descripcion { get; set; }
        public string EstadoPedido { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<PedidoDetalle> PedidoDetalle { get; set; }
    }
}
