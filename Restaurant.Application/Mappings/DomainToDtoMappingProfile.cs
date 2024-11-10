using AutoMapper;
using Restaurant.Application.DTOS;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Mappings;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<MenuItem, MenuItemDto>().ReverseMap();
        CreateMap<Order, OrderDto>().ReverseMap();
    }
}