using ArquiVision.Models;
using ArquiVision.Models.Modulo_Actividades;
using ArquiVision.Models.Modulo_Material;
using ArquiVision.Models.Modulo_Pedido;
using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PedidoDTO, Pedido>();
        CreateMap<Pedido, PedidoDTO>();
        CreateMap<ProductoVenta, ProductoVentaDTO>();
        CreateMap<ProductoVentaDTO, ProductoVenta>();
        CreateMap<ActividadDTO, Actividad>().ForMember(dest => dest.IdActividad, opt => opt.Ignore()) // Ignorar si no quieres actualizar
            .ForMember(dest => dest.UsuarioElimino, opt => opt.Ignore())
            .ForMember(dest => dest.UsuarioModifico, opt => opt.Ignore())
            .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
            .ForMember(dest => dest.FechaEliminacion, opt => opt.Ignore())
            .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore());

        CreateMap<Actividad, ActividadDTO>();
        // Puedes definir más mapeos aquí
    }
}