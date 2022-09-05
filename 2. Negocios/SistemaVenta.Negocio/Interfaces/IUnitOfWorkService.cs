using System;
namespace SistemaVenta.Negocio.Interfaces
{
    public interface IUnitOfWorkService: IDisposable
    {
        IProductoService ProductoService { get; }
        IUsuarioService UsuarioService { get; }
        ISeguridadService SeguridadService { get; }
    }
}
