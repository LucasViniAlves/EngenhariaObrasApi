using AutoMapper;
using EngenhariaObrasApi.DTOs;
using EngenhariaObrasApi.Models;

namespace EngenhariaObrasApi.Mappings
{
    public class BDIProfile : Profile
    {
        public BDIProfile()
        {
            CreateMap<BDI, BDIDTO>();
            CreateMap<BDICreateDTO, BDI>();
        }
    }
}
