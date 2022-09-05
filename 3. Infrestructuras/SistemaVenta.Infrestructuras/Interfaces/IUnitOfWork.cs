using AplicacionPersonal.Infraestructura.Interfaces;
using AutoMapper;
using SistemaVenta.Core.CustionEntities;
using SistemaVenta.Core.Entities;
using SistemaVenta.Infrestructuras.Interfaces;
using System;
using System.Threading.Tasks;

namespace SistemaVenta.Infraestructura.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductoRepository ProductoRepository { get; }       
        //IBaseRepository<Usuario> UsuarioRepository { get; }
        IBaseRepository<Cliente> ClienteRepository { get; }
        IBaseRepository<Pedido> PedidoRepository { get; }
        IBaseRepository<PedidoDetalle> PedidoDetalleRepository { get; }
        ISeguridadRepository SeguridadRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
        IMapper Mapper { get; }
        ITokenService TokenService { get; }
        PaginationOptions PaginationOptions { get; }
        public IUrlService UrlService { get; }
        public IPasswordService PasswordService { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
