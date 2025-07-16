using AutoMapper;
using EngenhariaObrasApi.DTOs;
using EngenhariaObrasApi.Models;

namespace EngenhariaObrasApi.Mappings
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<Material, MaterialDTO>();
            CreateMap<MaterialCreateDTO, Material>();
        }
    }
}
