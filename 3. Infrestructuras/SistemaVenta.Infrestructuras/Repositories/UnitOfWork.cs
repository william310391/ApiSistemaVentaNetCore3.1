using AplicacionPersonal.Infraestructura.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SistemaVenta.Core.CustionEntities;
using SistemaVenta.Core.Entities;
using SistemaVenta.Infraestructura.Data;
using SistemaVenta.Infraestructura.Interfaces;
using SistemaVenta.Infraestructura.Services;
using SistemaVenta.Infrestructuras.Interfaces;
using SistemaVenta.Infrestructuras.Options;
using SistemaVenta.Infrestructuras.Repositories;
using SistemaVenta.Infrestructuras.Services;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace SistemaVenta.Infraestructura.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VentasContext _context;
        private readonly IProductoRepository _productoRepository;
        private readonly ISeguridadRepository _seguridadRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        //private readonly IBaseRepository<Usuario> _usuarioRepository;
        private readonly IBaseRepository<Cliente> _clienteRepository;
        private readonly IBaseRepository<Pedido> _pedidoRepository;
        private readonly IBaseRepository<PedidoDetalle> _pedidoDetalleRepository;
        private readonly AutoMapper.IConfigurationProvider _configurationProvider;
        private readonly IMapper _mapper;
        private readonly PaginationOptions _paginationOptions;
        private readonly PasswordOptions _passwordOptions;
        private readonly IOptions<PasswordOptions> _ipasswordOptions;
        private readonly IUrlService _urlService;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly IPasswordService _passwordService;

        public UnitOfWork(VentasContext context, IMapper mapper, IOptions<PaginationOptions> options, IUrlService urlService, IConfiguration configuration, IOptions<PasswordOptions> passwordOptions, AutoMapper.IConfigurationProvider configurationProvider)
        {
            _context = context;
            _mapper = mapper;
            _paginationOptions = options.Value;
            _urlService = urlService;
            _configuration = configuration;
            _passwordOptions = passwordOptions.Value;
            _ipasswordOptions = passwordOptions;
            _configurationProvider = configurationProvider;
        }
        public IProductoRepository ProductoRepository => _productoRepository ?? new ProductoRepository(_context);
        //public IBaseRepository<Usuario> UsuarioRepository => _usuarioRepository ?? new BaseRepository<Usuario>(_context);
        public IBaseRepository<Cliente> ClienteRepository => _clienteRepository ?? new BaseRepository<Cliente>(_context);
        public IBaseRepository<Pedido> PedidoRepository => _pedidoRepository ?? new BaseRepository<Pedido>(_context);
        public IBaseRepository<PedidoDetalle> PedidoDetalleRepository => _pedidoDetalleRepository ?? new BaseRepository<PedidoDetalle>(_context);
        public IMapper Mapper => _mapper ?? new Mapper(_configurationProvider);
        public PaginationOptions PaginationOptions => _paginationOptions ?? new PaginationOptions();
        public PasswordOptions PasswordOptions => _passwordOptions ?? new PasswordOptions();
        public IUrlService UrlService => _urlService;
        public ITokenService TokenService => _tokenService ?? new TokenService(_configuration);
        public ISeguridadRepository SeguridadRepository => _seguridadRepository ?? new SeguridadRepository(_context);
        public IPasswordService PasswordService => _passwordService ?? new PasswordService(_ipasswordOptions);
        public IUsuarioRepository UsuarioRepository => _usuarioRepository ?? new UsuarioRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
           _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
