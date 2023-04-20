
using Aplication.Dto;
using AutoMapper;
using Domain.Models;
using Entity;

namespace Transversal.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Property, PropertyDto>().ReverseMap();
            CreateMap<Property, GetPropertyDto>().ReverseMap();
            CreateMap<PropertyMdl, GetPropertyDto>().ReverseMap();
            CreateMap<Municipio, GetMunicipioDto>().ReverseMap();
            CreateMap<Departamento, DepartamentoDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
        
    }
}