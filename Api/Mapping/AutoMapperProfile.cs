
using Api.Dtos;
using Api.Entities;
using AutoMapper;


namespace Infrestructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EncrypRequestDto,Encryps>();
        }
    }
}