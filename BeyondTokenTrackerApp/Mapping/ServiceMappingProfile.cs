using AutoMapper;
using TokenTracker.Domain.Entities.Dtos;
using TokenTracker.Domain.Entities.Models;

namespace TokenTrackerApp.Mapping
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
