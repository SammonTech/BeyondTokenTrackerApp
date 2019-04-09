using AutoMapper;
using Domain.Entities.Dtos;
using Domain.Entities.Models;

namespace BeyondTokenTrackerApp.Mapping
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile() : base("ServiceMappingProfile")
        {
            CreateMap<PointTransaction, TransactionDto>();

            CreateMap<User, UserDto>();

            CreateMap<Badge, BadgeDto>();

            CreateMap<PointTransactionType, TransactionTypeDto>();

            CreateMap<Product, ProductDto>();
        }

    }
}
