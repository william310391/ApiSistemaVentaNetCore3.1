using AutoMapper;
using SistemaVenta.Core.DTOs;
using SistemaVenta.Core.Entities;

namespace SistemaVenta.Negocio.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Producto, ProductoDTO>().ReverseMap();
            CreateMap<Seguridad, SeguridadDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
