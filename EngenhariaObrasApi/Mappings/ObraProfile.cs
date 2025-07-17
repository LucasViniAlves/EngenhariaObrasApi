using AutoMapper;
using EngenhariaObrasApi.Models;
using EngenhariaObrasApi.DTOs;

namespace EngenhariaObrasApi.Mappings
{
    public class ObraProfile : Profile
    {
        public ObraProfile()
        {
            // Mapeamento principal da entidade Obra para o DTO
            CreateMap<Obra, ObraDTO>()
                .ForMember(dest => dest.Materiais, opt => opt.MapFrom(src => src.ObrasMateriais))
                .ForMember(dest => dest.MaoDeObras, opt => opt.MapFrom(src => src.MaoDeObras))
                .ForMember(dest => dest.CustosAdicionais, opt => opt.MapFrom(src => src.CustosAdicionais))
                .ForMember(dest => dest.BDI, opt => opt.MapFrom(src => src.BDI));

            // Mapeia da associação ObrasMateriais para o DTO que carrega quantidade e dados do material
            CreateMap<ObrasMateriais, ObraMaterialDTO>()
                .ForMember(dest => dest.IdMaterial, opt => opt.MapFrom(src => src.Material.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Material.Nome))
                .ForMember(dest => dest.PrecoUnitario, opt => opt.MapFrom(src => src.Material.PrecoUnitario))
                .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(src => src.Quantidade));

            CreateMap<ObraCreateDTO, Obra>();
        }
    }
}
