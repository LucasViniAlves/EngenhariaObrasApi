using AutoMapper;
using EngenhariaObrasApi.DTOs;
using EngenhariaObrasApi.Models;

namespace EngenhariaObrasApi.Mappings
{
    public class MaoDeObraProfile : Profile
    {
        public MaoDeObraProfile()
        {
            CreateMap<MaoDeObra, MaoDeObraDTO>();
            CreateMap<MaoDeObraCreateDTO, MaoDeObra>();
        }
    }
}
