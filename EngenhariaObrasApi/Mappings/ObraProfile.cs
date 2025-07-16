using AutoMapper;
using EngenhariaObrasApi.Models;
using EngenhariaObrasApi.DTOs;

namespace EngenhariaObrasApi.Mappings
{
    public class ObraProfile : Profile
    {
        public ObraProfile()
        {
            CreateMap<Obra, ObraDTO>()
            .ForMember(dest => dest.Materiais, opt => opt.MapFrom(src => src.ObrasMateriais.Select(om => om.Material)))
            .ForMember(dest => dest.MaoDeObras, opt => opt.MapFrom(src => src.MaoDeObras))
            .ForMember(dest => dest.CustosAdicionais, opt => opt.MapFrom(src => src.CustosAdicionais))
            .ForMember(dest => dest.BDI, opt => opt.MapFrom(src => src.BDI));
            CreateMap<ObraCreateDTO, Obra>();
        }
    }
}
