using AutoMapper;
using TestJobForUralsib.Domain.Models;

namespace TestJobForUralsib.Domain.DTOs.mapping.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
        }
    }
}
