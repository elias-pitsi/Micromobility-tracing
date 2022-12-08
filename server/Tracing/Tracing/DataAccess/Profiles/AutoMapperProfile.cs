using Tracing.DataAccess.Dtos;
using Tracing.DataAccess.Models;

namespace Tracing.DataAccess.Profiles;
using AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Owner, OwnerRegistrationDto>().ReverseMap();
        CreateMap<OwnerDto, Owner>().ReverseMap();
        CreateMap<ComponentDetails, ComponentsDto>();
        CreateMap<Bike, BikeDto>().ReverseMap(); ;
        CreateMap<ComponentDetails, BikeComponentsDto>().ReverseMap();
        CreateMap<Owner, ResetPasswordRequest>().ReverseMap();
        CreateMap<HistoryDto, ComponentsHistory>().ReverseMap();
    }

}