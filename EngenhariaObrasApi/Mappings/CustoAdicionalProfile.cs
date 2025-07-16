using AutoMapper;
using EngenhariaObrasApi.DTOs;
using EngenhariaObrasApi.Models;

namespace EngenhariaObrasApi.Mappings
{
    public class CustoAdicionalProfile : Profile
    {
        public CustoAdicionalProfile()
        {
            CreateMap<CustoAdicional, CustoAdicionalDTO>();
            CreateMap<CustoAdicionalCreateDTO, CustoAdicional>();
        }
    }
}
