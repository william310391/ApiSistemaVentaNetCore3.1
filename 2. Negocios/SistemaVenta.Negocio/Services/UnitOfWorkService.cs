using SistemaVenta.Infraestructura.Interfaces;
using SistemaVenta.Negocio.Interfaces;

namespace SistemaVenta.Negocio.Services
{
    public class UnitOfWorkService: IUnitOfWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductoService _productoService;
        private readonly IUsuarioService _usuarioService;
        private readonly ISeguridadService _seguridadService;



        public UnitOfWorkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   

        }
        public IProductoService ProductoService => _productoService ?? new ProductoService(_unitOfWork);
        public IUsuarioService UsuarioService => _usuarioService ?? new UsuarioService(_unitOfWork);
        public ISeguridadService SeguridadService => _seguridadService ?? new SeguridadService(_unitOfWork);


        public void Dispose()
        {
            if (_unitOfWork != null)
            {
                _unitOfWork.Dispose();
            }
        }
    }
}
